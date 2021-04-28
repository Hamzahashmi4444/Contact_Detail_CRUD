<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="CRUD_OPERATION.Contacts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <asp:HiddenField ID="hfcontactID" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Names"></asp:Label>

                        </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Mobile"></asp:Label>

                        </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Addresss"></asp:Label>

                        </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                  
                    <td colspan="2">
                        <asp:Button ID="Btn_Save" runat="server" Text="Save" OnClick="Btn_Save_Click" />
                        <asp:Button ID="Btn_Delete" runat="server" Text="Delete" OnClick="Btn_Delete_Click" />
                        <asp:Button ID="Btn_Clear" runat="server" Text="Clear" OnClick="Btn_Clear_Click" />
                    </td>
                </tr>

                  <tr>
                  
                    <td colspan="2">
                        <asp:Label ID="LblSuccessMessage" runat="server" Text="" ForeColor ="Green"></asp:Label>
                    </td>
                </tr>

                  <tr>
                  
                    <td colspan="2">
                       <asp:Label ID="LblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
              
                  </table>
              <br />
                <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns ="false">
                    <Columns>
                        <asp:BoundField DataField="Names" HeaderText="Names" />
                        <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                        <asp:BoundField DataField="Addresss" HeaderText="Addresss" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LnkView" runat="server" CommandArgument='<%# Eval("ContactID")%>' OnClick="lnk_OnClick">view</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                   
   
        
        </div>
    </form>
</body>
</html>
