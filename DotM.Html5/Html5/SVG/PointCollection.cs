using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;

namespace DotM.Html5.SVG
{
    [Serializable]
    public class PointCollection : List<Point>
    {
        public PointCollection() { }
        public PointCollection(IEnumerable<Point> points): base(points) { }

        public override string ToString()
        {
            return string.Join(",", this.Select(n => n.ToString(' ')));
        }
        public static PointCollection Parse(string input)
        {
            var parser = new PointCollectionParser(input);
            return new PointCollection(parser.Points);
        }
        public static implicit operator string(PointCollection collection)
        {
            if (collection == null)
                return null;
            return collection.ToString();
        }
        public static implicit operator PointCollection(string input)
        {
            if (input == null)
                return null;
            return PointCollection.Parse(input);
        }

        private class PointCollectionParser
        {
            private string Input;
            private int LookAhead;
            private Token PrevToken;
            public IEnumerable<Point> Points { get; private set; }
            public PointCollectionParser(string input)
            {
                Input = input;
                LookAhead = 0;
                Points = Parse();
            }
            private IEnumerable<Point> Parse()
            {
                Token x, y, unitSeperator, pointSeperator;
                while ((x = GetNextToken()) != null)
                {
                    unitSeperator = GetNextToken();
                    y = GetNextToken();
                    pointSeperator = GetNextToken();
                    if (unitSeperator == null || y == null
                        || (pointSeperator != null && pointSeperator.Type == unitSeperator.Type)
                        || x.Type != TokenType.Unit || y.Type != TokenType.Unit)
                        ThrowFormatException();
                    yield return new Point(x.Unit, y.Unit);
                }
            }
            private Token GetNextToken()
            {
                if (LookAhead >= Input.Length)
                    return null;
                var chars = new List<char>();
                var tokenType = GetTokenType(Input[LookAhead]);
                do
                {
                    chars.Add(Input[LookAhead]);
                    LookAhead++;
                }
                while (LookAhead < Input.Length && GetTokenType(Input[LookAhead]) == tokenType);
                var token = CreateToken(chars, tokenType);
                if (PrevToken != null && PrevToken.Type != TokenType.Unit && token.Type == TokenType.Space)
                    return GetNextToken();
                return (PrevToken = token);
            }

            private Token CreateToken(List<char> chars, TokenType tokenType)
            {
                if (tokenType == TokenType.Unit)
                {
                    Unit unit;
                    if (!Helper.TryParseUnit(new string(chars.ToArray()), out unit))
                        ThrowFormatException();
                    return new Token(TokenType.Unit, unit);
                }
                return new Token(tokenType, Unit.Empty);
            }

            private void ThrowFormatException()
            {
                throw new FormatException("Input wan not in correct format: " + Input);
            }
            private TokenType GetTokenType(char c)
            {
                switch (c)
                {
                    case ',':
                        return TokenType.Comma;
                    case ' ':
                        return TokenType.Space;
                    default:
                        return TokenType.Unit;
                }
            }
            private class Token
            {
                public Unit Unit { get; private set; }
                public TokenType Type { get; private set; }
                public Token(TokenType type, Unit unit)
                {
                    Type = type;
                    Unit = unit;
                }
            }
            private enum TokenType
            {
                None,
                Unit,
                Comma,
                Space
            }
        }
    }
}