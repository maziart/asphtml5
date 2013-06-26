<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC.ascx.cs" Inherits="SVGTest.UC" %>
<svg:Svg runat="server" Width="24cm" Height="15cm" ViewBox="0 0 1640 1040" ID="mySvg">
    <svg:Group runat="server" ID="house">
        <svg:Rectangle ID="Rectangle1" runat="server" Start="0 41" Size="60 60" Stroke="Black"
            ZIndex="8" Fill="Yellow" />
        <!-- roof  -->
        <svg:PolyLine ID="PolyLine1" runat="server" Stroke="Black" Fill="Blue" />
        <!-- door brown-->
        <svg:PolyLine ID="PolyLine2" runat="server" Points="30 101, 30 71, 44 71, 44 101"
            ZIndex="9" Stroke="Black" Fill="brown" />
    </svg:Group>
    <svg:Rectangle runat="server" X="100" Y="100" Width="400" Height="200" RX="50" Fill="none"
        ZIndex="4" Stroke="purple" StrokeWidth="30">
        <animate attributetype="CSS" attributename="opacity" from="1" to="0.5" dur="1s" fill="freeze"
            repeatcount="0" />
    </svg:Rectangle>
    <svg:Ellipse ID="Ellipse1" runat="server" Center="300 200" RadiusX="150" RadiusY="75"
        ZIndex="6" />
    <svg:Circle runat="server" Center="300 200" Radius="75" Fill="White" ZIndex="8" />
    <svg:PolyLine runat="server" Fill="none" Stroke="blue" StrokeWidth="10" Points="50,375
                    150,375 150,325 250,325 250,375
                    350,375 350,500 450,500 450,375
                    550,375 550,175 650,175 650,375
                    750,375 750,100 850,100 850,375
                    950,375 950,25 1050,25 1050,375
                    1150,375" />
    <svg:Polygon runat="server" Points="350,75  379,161 469,161 397,215
                    423,301 350,250 277,301 303,215
                    231,161 321,161" Fill="Purple" Transform="translate(800 300)">
    </svg:Polygon>
    <svg:Path runat="server" ID="MyPath" Stroke="Black" Fill="none" StrokeWidth="5" Transform="translate(0 500)"
        PathLength="100" />
    <svg:Path runat="server" ID="Path2" Stroke="Black" Fill="none" StrokeWidth="5" Commands="M10,10L100,10L100,100H10ZL100 100"
        Transform="translate(500, 0)">
    </svg:Path>
    <svg:Use ID="Use1" runat="server" Reference="house" Transform="translate(300 200) scale(1.2) rotate(10)"
        ZIndex="3">
    </svg:Use>
    <svg:Use ID="Use2" runat="server" Reference="house"  Transform="translate(0 500)">
        <animatemotion dur="6s" rotate="auto" fill="freeze">
            <mpath xlink:href="#UC1_MyPath"/>
        </animatemotion>
    </svg:Use>
</svg:Svg>
<asp:Button Text="Up" runat="server" OnClick="Unnamed2_Click" />
