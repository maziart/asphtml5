<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Herald.aspx.cs" Inherits="Samples.Herald" %>

<!DOCTYPE html>
<html class=" js flexbox canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms no-csstransforms3d csstransitions fontface video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths"
lang="en">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <link rel="stylesheet" href="~/Herald/Styles.css" />
    <link rel="stylesheet" href="~/Herald/Screen.css" />
    <script src="./Herald/modernizr-1.7.min.js"></script>
    <title>The HTML 5 Herald</title>
</head>
<body class="hyphenate">
    <html5:Header runat="server">
        <html5:HGroup runat="server">
            <h1>
                <span>The </span><a href="#">HTML5
                    <asp:Image runat="server" ImageUrl="~/Herald/logo.png" />
                    Her­ald</a>
            </h1>
            <h2>
                Pro­duced with That Good ol' Timey HTML5 &amp; CSS3
            </h2>
        </html5:HGroup>
        <html5:Nav runat="server">
            <ul>
                <li>
                    <asp:HyperLink runat="server" NavigateUrl="~/ViewCode.aspx?p=Herald.aspx" Text="Herald.aspx"></asp:HyperLink></li>
                <li>
                    <asp:HyperLink runat="server" NavigateUrl="~/ViewCode.aspx?p=Herald.aspx.cs" Text="Herald.aspx.cs"></asp:HyperLink></li>
            </ul>
        </html5:Nav>
        <p id="volume">
            Vol. MMXI</p>
        <p id="issue">
            <html5:Time runat="server" DateTime="1904-06-04" IsPubDate="true">
                June 4, 1904</html5:Time>
        </p>
    </html5:Header>
    <div id="main">
        <div id="primary">
            <html5:Article runat="server" ID="ac1" ClientIDMode="Static">
                <div id="video-container">
                    <html5:Video runat="server" Width="373" Height="280" PreLoad="Auto" ID="video" ClientIDMode="Static"
                        Poster="./Herald/ford-plane-still.png">
                        <!-- MP4 must be first for iPad! -->
                        <html5:Source runat="server" Url="~/Herald/ford-plane-takes-off.mp4" Type="video/mp4" /><!-- Safari / iOS video -->
                        <html5:Source runat="server" Url="~/Herald/ford-plane-takes-off.ogv" Type="video/ogg" /><!-- Firefox / Opera / Chrome10 -->
                        <asp:Image runat="server" ImageUrl="~/Herald/ford-plane-still.png" ID="videoStill" ClientIDMode="Static"
                            Width="373" Height="280" AlternateText="Airplane" />
                    </html5:Video>
                    <html5:Canvas runat="server" ID="canvasOverlay" ClientIDMode="Static" Width="373" Height="280"></html5:Canvas>
                    <div id="controls" class="">
                        <div id="playPause" class="paused" tabindex="1">
                            Play/Pause</div>
                        <div id="timer">
                            00:00</div>
                        <div id="muteUnmute" class="unmuted" tabindex="2">
                            Mute/Un­mute</div>
                    </div>
                </div>
                <!-- /#video-container -->
                <h1>
                    Video is the final fron­tier, and now we have con­quered it!</h1>
                <div class="content">
                    <p>
                        Ali­quam erat vo­lut­pat. Mau­ris vel neque sit amet nunc gravida congue sed sit
                        amet purus. Quisque lacus quam, eges­tas ac tin­cidunt a, lacinia vel velit. Morbi
                        ac com­modo nulla.</p>
                    <p>
                        In condi­men­tum orci id nisl vo­lut­pat biben­dum. Quisque com­modo hen­drerit
                        lorem quis eges­tas. Vi­va­mus rutrum nunc non neque con­secte­tur quis plac­erat
                        neque lobor­tis. Nam vestibu­lum, arcu so­dales feu­giat con­secte­tur, nisl orci
                        biben­dum elit, eu eu­is­mod magna sapien ut nibh. Ali­quam erat vo­lut­pat. Mau­ris
                        vel neque sit amet nunc gravida congue sed sit amet purus.</p>
                    <p>
                        Quisque lacus quam, eges­tas ac tin­cidunt a, lacinia vel velit. Morbi ac com­modo
                        nulla. In condi­men­tum orci id nisl vo­lut­pat biben­dum. Quisque com­modo hen­drerit
                        lorem quis eges­tas. Vi­va­mus rutrum nunc non neque con­secte­tur quis plac­erat
                        neque lobor­tis. Nam vestibu­lum, arcu so­dales feu­giat con­secte­tur, nisl orci
                        biben­dum elit, eu eu­is­mod magna sapien ut nibh.</p>
                    <p>
                        Neque sit amet nunc gravida congue sed sit amet purus. Quisque lacus quam, eges­tas
                        ac tin­cidunt a, lacinia vel velit. Morbi ac com­modo nulla. In condi­men­tum orci
                        id nisl vo­lut­pat biben­dum. Quisque com­modo hen­drerit lorem quis eges­tas. Vi­va­mus
                        rutrum nunc non neque con­secte­tur quis plac­erat neque lobor­tis. Nam vestibu­lum,
                        arcu so­dales feu­giat con­secte­tur, nisl orci biben­dum elit, eu eu­is­mod magna
                        sapien ut nibh.</p>
                </div>
            </html5:Article>
            <html5:Article runat="server">
                <h1>
                    Great Things Are Pos­si­ble with CSS Columns! Pip Pip Pip!</h1>
                <div class="content">
                    <p>
                        Mae­ce­nas quis tor­tor arcu. Vi­va­mus rutrum nunc non neque con­secte­tur quis
                        plac­erat neque lobor­tis. Nam vestibu­lum, arcu so­dales feu­giat con­secte­tur,
                        nisl orci biben­dum elit, eu eu­is­mod magna sapien ut nibh.</p>
                    <p>
                        Nunc eu ul­lam­cor­per orci. Quisque eget odio ac lec­tus vestibu­lum fau­cibus
                        eget in metus. In pel­len­tesque fau­cibus vestibu­lum. Nulla at nulla justo, eget
                        luc­tus tor­tor. Nulla fa­cil­isi. Duis ali­quet eges­tas purus in blandit.
                    </p>
                    <p>
                        Quisque lacus quam, eges­tas ac tin­cidunt a, lacinia vel velit. Morbi ac com­modo
                        nulla. In condi­men­tum orci id nisl vo­lut­pat biben­dum. Quisque com­modo hen­drerit
                        lorem quis eges­tas. Vi­va­mus rutrum nunc non neque con­secte­tur quis plac­erat
                        neque lobor­tis. Nam vestibu­lum, arcu so­dales feu­giat con­secte­tur, nisl orci
                        biben­dum elit, eu eu­is­mod magna sapien ut nibh.</p>
                    <p>
                        Neque sit amet nunc gravida congue sed sit amet purus. Quisque lacus quam, eges­tas
                        ac tin­cidunt a, lacinia vel velit. Morbi ac com­modo nulla. In condi­men­tum orci
                        id nisl vo­lut­pat biben­dum. Quisque com­modo hen­drerit lorem quis eges­tas. Vi­va­mus
                        rutrum nunc non neque con­secte­tur quis plac­erat neque lobor­tis. Nam vestibu­lum,
                        arcu so­dales feu­giat con­secte­tur, nisl orci biben­dum elit, eu eu­is­mod magna
                        sapien ut nibh.</p>
                    <p>
                        Nunc eu ul­lam­cor­per orci. Quisque eget odio ac lec­tus vestibu­lum fau­cibus
                        eget in metus. In pel­len­tesque fau­cibus vestibu­lum. Nulla at nulla justo, eget
                        luc­tus tor­tor. Nulla fa­cil­isi. Duis ali­quet eges­tas purus in blandit.
                    </p>
                </div>
            </html5:Article>
        </div>
        <div id="secondary">
            <html5:Article runat="server" ID="ac2" ClientIDMode="Static">
                <html5:HGroup runat="server">
                    <h1>
                        Text Shadow is the New Black</h1>
                    <h2>
                        How do we do it?</h2>
                </html5:HGroup>
                <div class="content">
                    <p>
                        Mae­ce­nas quis tor­tor arcu. Vi­va­mus rutrum nunc non neque con­secte­tur quis
                        plac­erat neque lobor­tis. Nam vestibu­lum, arcu so­dales feu­giat con­secte­tur,
                        nisl orci biben­dum elit, eu eu­is­mod magna sapien ut nibh.</p>
                    <p>
                        Nunc eu ul­lam­cor­per orci. Quisque eget odio ac lec­tus vestibu­lum fau­cibus
                        eget in metus. In pel­len­tesque fau­cibus vestibu­lum. Nulla at nulla justo, eget
                        luc­tus tor­tor. Nulla fa­cil­isi. Duis ali­quet eges­tas purus in blandit.
                    </p>
                </div>
            </html5:Article>
            <html5:Article runat="server" ID="ac3" ClientIDMode="Static">
                <html5:HGroup runat="server">
                    <h1>
                        Wai-Aria? HAHA!</h1>
                    <h2 id="catHeading">
                        Form Ac­ces­si­bil­ity</h2>
                </html5:HGroup>
                <asp:Image runat="server" ImageUrl="~/Herald/cat.png" ID="cat" ClientIDMode="Static"
                    AlternateText="WAI-ARIA Cat" />
                <div class="content">
                    <p id="mouseContainer">
                        <asp:Image runat="server" ImageUrl="~/Herald/computer-mouse-pic.png" Width="30" AlternateText="mouse treat"
                            ID="mouse1" ClientIDMode="Static" draggable="true" />
                        <asp:Image runat="server" ImageUrl="~/Herald/computer-mouse-pic.png" Width="30" AlternateText="mouse treat"
                            ID="mouse2" ClientIDMode="Static" draggable="true" />
                        <asp:Image runat="server" ImageUrl="~/Herald/computer-mouse-pic.png" Width="30" AlternateText="mouse treat"
                            ID="mouse3" ClientIDMode="Static" draggable="true" />
                    </p>
                    <p>
                        Mae­ce­nas quis tor­tor arcu. Vi­va­mus rutrum nunc non neque con­secte­tur quis
                        plac­erat neque lobor­tis. Nam vestibu­lum, arcu so­dales feu­giat con­secte­tur,
                        nisl orci biben­dum.</p>
                    <p>
                        Nam vestibu­lum, arcu so­dales feu­giat.</p>
                </div>
            </html5:Article>
            <html5:Article runat="server" ID="ac4" ClientIDMode="Static">
                <html5:HGroup runat="server">
                    <h1>
                        Mod­ern­izr Times</h1>
                    <h2>
                        A New Era</h2>
                </html5:HGroup>
                <div class="content">
                    <p>
                        Mae­ce­nas quis tor­tor arcu. Vi­va­mus rutrum nunc non neque con­secte­tur quis
                        plac­erat neque lobor­tis. Nam vestibu­lum, arcu so­dales feu­giat con­secte­tur,
                        nisl orci biben­dum.</p>
                    <p>
                        Nunc eu ul­lam­cor­per orci. Quisque eget odio ac lec­tus vestibu­lum fau­cibus
                        eget in metus. In pel­len­tesque fau­cibus vestibu­lum. Nulla at nulla justo, eget
                        luc­tus tor­tor. Nulla fa­cil­isi. Duis ali­quet eges­tas purus in blandit.
                    </p>
                </div>
            </html5:Article>
        </div>
        <div id="tertiary">
            <html5:Aside runat="server">
                <html5:Article runat="server" ID="ad1" ClientIDMode="Static">
                    <h1>
                        Wanted</h1>
                    <p>
                        Dead or Alive</p>
                    <a href="http://sitepoint.com/books/htmlcss1/" class="wanted">&lt;HTML5&gt; &amp; {CSS3}</a>
                    <p>
                        Re­ward: Hap­pi­ness and sat­is­fac­tion</p>
                </html5:Article>
                <html5:Article runat="server" ID="ad3" ClientIDMode="Static">
                    <h1>
                        Put your <span>dukes</span> up sire</h1>
                    <p>
                        It’s time for a good old thrash­ing.<br>
                        I will ro­tate your mous­tache OFF!</p>
                </html5:Article>
                <html5:Article runat="server" ID="ad2" ClientIDMode="Static">
                    <h1>
                        <a href="http://sitepoint.com/books/htmlcss1/">HTML5 and CSS3
                            <br>
                            Now in Book Form!</a></h1>
                </html5:Article>
                <html5:Article runat="server" ID="ad4" ClientIDMode="Static">
                    <div id="formDiv">
                        <h2>
                            Enter An Email</h2>
                        <form id="emailForm" runat="server">
                        <html5:EmailInput ID="Email1" runat="server" Required="true" Width="150px"></html5:EmailInput>
                        <asp:Label ID="Label1" runat="server" Text="Age is disabled"></asp:Label>
                        <html5:NumberInput ID="Number1" Minimum="18" Maximum="457" Enabled="false" runat="server"
                            Width="150px"></html5:NumberInput>
                        <asp:Button Text="Submit" runat="server" ID="Button1" OnClick="Button1_Submit" />
                        </form>
                    </div>
                </html5:Article>
            </html5:Aside>
            <html5:Article runat="server" ID="ac5" ClientIDMode="Static">
                <html5:HGroup runat="server">
                    <h1>
                        CSS Tran­si­tions - The State of Play</h1>
                    <h2>
                        The fu­ture?</h2>
                </html5:HGroup>
                <div class="content">
                    <p>
                        Mae­ce­nas quis tor­tor arcu. Vi­va­mus rutrum nunc non neque con­secte­tur quis
                        plac­erat neque lobor­tis. Nam vestibu­lum, arcu so­dales feu­giat con­secte­tur,
                        nisl orci biben­dum elit, eu eu­is­mod magna sapien ut nibh.</p>
                    <p>
                        Nunc eu ul­lam­cor­per orci. Quisque eget odio ac lec­tus vestibu­lum fau­cibus
                        eget in metus. In pel­len­tesque fau­cibus vestibu­lum.</p>
                    <p>
                        Vi­va­mus rutrum nunc non neque con­secte­tur quis plac­erat neque lobor­tis. Nam
                        vestibu­lum, arcu so­dales feu­giat con­secte­tur, nisl orci biben­dum elit, eu
                        eu­is­mod magna sapien ut nibh.</p>
                    <p>
                        Nunc eu ul­lam­cor­per orci. Quisque eget odio ac lec­tus vestibu­lum fau­cibus
                        eget in metus. In pel­len­tesque fau­cibus vestibu­lum. Nulla at. vestibu­lum. Nulla
                        at.</p>
                    <p>
                        Vi­va­mus rutrum nunc non neque con­secte­tur quis plac­erat neque lobor­tis. Nam
                        vestibu­lum, arcu so­dales feu­giat con­secte­tur, nisl orci biben­dum elit, eu
                        eu­is­mod magna sapien ut nibh.</p>
                </div>
            </html5:Article>
        </div>
    </div>
    <html5:Footer runat="server">
        <html5:Section runat="server" ID="authors" ClientIDMode="Static">
            <html5:Section runat="server">
                <h1>
                    Alexis Gold­stein</h1>
                <p>
                    Mae­ce­nas quis tor­tor arcu. Vi­va­mus rutrum nunc non neque con­secte­tur quis
                    plac­erat neque lobor­tis. Nam vestibu­lum, arcu so­dales feu­giat con­secte­tur,
                    nisl orci biben­dum elit, eu eu­is­mod magna sapien ut nibh.</p>
            </html5:Section>
            <html5:Section runat="server">
                <h1>
                    Louis Lazaris</h1>
                <p>
                    Mae­ce­nas quis tor­tor arcu. Vi­va­mus rutrum nunc non neque con­secte­tur quis
                    plac­erat neque lobor­tis. Nam vestibu­lum, arcu so­dales feu­giat con­secte­tur,
                    nisl orci biben­dum elit, eu eu­is­mod magna sapien ut nibh.</p>
            </html5:Section>
            <html5:Section runat="server">
                <h1>
                    Es­telle Weyl</h1>
                <p>
                    Mae­ce­nas quis tor­tor arcu. Vi­va­mus rutrum nunc non neque con­secte­tur quis
                    plac­erat neque lobor­tis. Nam vestibu­lum, arcu so­dales feu­giat con­secte­tur,
                    nisl orci biben­dum elit, eu eu­is­mod magna sapien ut nibh.</p>
            </html5:Section>
        </html5:Section>
        <html5:Section runat="server" ID="footerinfo" ClientIDMode="Static">
            <small>© Site­Point </small>
            <p>
                <a href="http://www.sitepoint.com/">
                    <asp:Image ImageUrl="~/Herald/logo-sp.png" AlternateText="SitePoint" Width="70" Height="23" /></a></p>
        </html5:Section>
    </html5:Footer>
    <script src="./Herald/hyphenator.js"></script>
    <script src="./Herald/raphael-min.js"></script>
    <script src="jquery.min.js"></script>
    <script src="./Herald/videoControls.js"></script>
    <script src="./Herald/dragDrop.js"></script>
    <script src="./Herald/videoToBW.js"></script>
</body>
</html>
