<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="vt14_1_4_gissa_det_hemliga_talet.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        <asp:Button ID="GuessButton" runat="server" Text="Skicka gissning" /><br />
        <asp:PlaceHolder ID="HaveGuessed" runat="server" Visible="false">
            <asp:Label ID="OldGuesses" runat="server" Text=""></asp:Label><asp:Label ID="Result" runat="server" Text=""></asp:Label>
        </asp:PlaceHolder>
        <asp:Label ID="Fail" runat="server" Text="Du har inga gissningar kvar. Det hemliga talet var {0}." Visible="false"></asp:Label>
        <asp:Button ID="Restart" runat="server" Text="Slumpa nytt hemligt tal" Visible="false" />
    </div>
    </form>
</body>
</html>
