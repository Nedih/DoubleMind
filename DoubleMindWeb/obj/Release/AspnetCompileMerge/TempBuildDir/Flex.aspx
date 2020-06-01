<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Flex.aspx.cs" Inherits="DoubleMindWeb.Views.Comment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 585px; width: 1359px">
    <form id="form1" runat="server">
        <div>
            <div id="formDesign">
            <table>
            <tr><td><p>Comment</p></td>
                <td><p>
                    <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </p></td>
            </tr>
            <tr>
                <td><p>Rating</p></td>
                <td></td>
            </tr>
                <tr><td></td>
                   <td><asp:Button ID="btn_Submit" runat="server" Text="Comment" BackColor="#3366FF" BorderStyle="Groove" ForeColor="White" Width="102px" /></td>
                </tr>
        </table>
                     </div>
            <h4 style="text-decoration:underline;">Comments:</h4>
            <div>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <div style="margin-top: 15px; border: solid 2px">
                        <b>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Name") %>'>'></asp:Label></b>&nbsp;(<asp:Label ID="Label2" runat="server" Text='<%#Eval("Email") %>'>'></asp:Label>):<br />
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("Comment") %>'></asp:Label><br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
                </div>
            <div style="overflow: hidden; margin-top: 214px;">
                <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnPage"
                            Style="padding: 8px; margin: 2px; background: #007acc; border: solid 1px blue; font: 8px;"
                            CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                            runat="server" ForeColor="White" Font-Bold="True" CausesValidation="false"><%# Container.DataItem %>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
