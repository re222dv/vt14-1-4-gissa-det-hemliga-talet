<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="vt14_1_4_gissa_det_hemliga_talet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Gissa det hemliga talet</h1>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="error" BorderStyle="NotSet" />
        Ange tal mellan 1 och 100:
        <asp:TextBox ID="Guess" runat="server" TextMode="Number" autofocus="autofocus"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Gissning måste fyllas i" ControlToValidate="Guess" Display="None"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Gissningen måste vara mellan 1 och 100" ControlToValidate="Guess" Display="None" Type="Integer" MinimumValue="1" MaximumValue="100"></asp:RangeValidator>
        <asp:Button ID="GuessButton" runat="server" Text="Skicka gissning" OnClick="GuessButton_Click" /><br />
        <asp:PlaceHolder ID="HaveGuessed" runat="server" Visible="false">
            <p>
                <asp:Label ID="OldGuesses" runat="server" Text=""></asp:Label>
                <asp:Label ID="Result" runat="server" Text=""></asp:Label>
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="HaveFailed" runat="server" Visible="false">
            <p>
                <asp:Label ID="Fail" runat="server" Text="Du har inga gissningar kvar. Det hemliga talet var {0}."></asp:Label>
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="Done" runat="server" Visible="false">
            <p>
                <asp:Button ID="Restart" runat="server" Text="Slumpa nytt hemligt tal" OnClick="Restart_Click" CausesValidation="False" />
            </p>
        </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
