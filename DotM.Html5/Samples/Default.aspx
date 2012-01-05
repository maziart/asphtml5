<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Samples.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-family:Tahoma" >
    <h2>About HTML5 Herald:</h2>
    <p>
        The HTML5 Herald is a website associated with the book <a href="http://www.sitepoint.com/books/htmlcss1/">
            HTML5 & CSS 3 For The Real World</a> which is a tutorial for HTML5 and CSS3.
        The main website is located at <a href="http://www.thehtml5herald.com">http://www.thehtml5herald.com</a>.
        I have re-built the website using ASP.NET and DotM.HTML5 controls with some minor
        changes in it. This website is a good HTML5 sample and is a good way of starting
        HTML5. Here you can see the ASP.NET version of HTML5 Herald with it's source codes.
    </p>
    <ul>
        <li>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Herald.aspx" Text="HTML5 Herald"></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ViewCode.aspx?p=Herald.aspx"
                Text="HTML5 Herald.aspx Source Code"></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/ViewCode.aspx?p=Herald.aspx.cs"
                Text="HTML5 Herald.aspx.cs Source Code"></asp:HyperLink></li>
    </ul>

    
    <hr />
    <span>This code is licensed under Microsoft public license (MS-PL)</span>
</body>
</html>
