<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AskQuestion.aspx.cs" Inherits="AskAndTell.AskQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <asp:TextBox ID="TextBox1" runat="server" Height="262px" Width="510px"></asp:TextBox>
        <ajaxToolkit:HtmlEditorExtender ID="TextBox1_HtmlEditorExtender" runat="server" BehaviorID="TextBox1_HtmlEditorExtender" TargetControlID="TextBox1" EnableSanitization="false">
        </ajaxToolkit:HtmlEditorExtender>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </p>
    </form>
</body>
</html>
