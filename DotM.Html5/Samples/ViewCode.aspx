<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCode.aspx.cs" Inherits="Samples.ViewCode" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>View Code</title>
    <link type="text/css"  rel="Stylesheet" href="./prettify/prettify.css" />  
    <script type="text/javascript" language="javascript" src="jquery.min.js"></script>
    <script type="text/javascript" language="javascript" src="./prettify/prettify.js"></script>
    <script type="text/javascript" language="javascript" src="./prettify/lang-sql.js"></script>
    <script type="text/javascript" language="javascript" src="./prettify/lang-vb.js"></script>
    <script type="text/javascript" language="javascript" src="./prettify/lang-css.js"></script>
    <script type="text/javascript" language="javascript" src="./prettify/lang-wiki.js"></script>
    <script type="text/javascript" language="javascript" src="./prettify/lang-vhdl.js"></script>
    <script>
        $(document).ready(function () {
            prettyPrint();
        });
    </script>
    <style>
        .prettyprint
        {
            direction: ltr;
            text-align: left;
            font-size: small;
            border: solid 1px black;
            background-color:White;
            white-space:pre-wrap;
        }
    </style>
</head>
<body style="background-color:#c9c0ff; font-family:Tahoma">
    <asp:Label Text="" ID="LblHeader" runat="server" />
    <pre class="prettyprint" runat="server" id="codeContainer">
    </pre>
    <asp:Label Text="" ID="LblFooter" runat="server" />

    <hr />
    <span>This code is licensed under Microsoft public license (MS-PL)</span>
</body>
</html>
