<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="page-container">
    <div class="container">
        <asp:UpdatePanel runat="server" ID="updatePanel" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="input-row row">
                    <label>姓名:</label>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                        Display="Dynamic" ErrorMessage="請輸入姓名" ValidationGroup="SubmitValidation"></asp:RequiredFieldValidator>
                </div>
                <div class="input-row row">
                    <label>年齡:</label>
                    <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAge" runat="server" ControlToValidate="txtAge"
                        Display="Dynamic" ErrorMessage="請輸入年齡" ValidationGroup="SubmitValidation"></asp:RequiredFieldValidator>
                </div>
                <div class="input-row row">
                    <label>生日:</label>
                    <asp:TextBox ID="txtBirthday" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvBirthday" runat="server" ControlToValidate="txtBirthday"
                        Display="Dynamic" ErrorMessage="請輸入生日" ValidationGroup="SubmitValidation"></asp:RequiredFieldValidator>
                </div>
                <div class="input-row row">
                    <% if (editId == 0) { %>
                        <asp:Button ID="btnSubmit" runat="server" Text="建立帳號" OnClick="btnSubmit_Click" ValidationGroup="SubmitValidation"/>
                    <% } else { %>
                        <asp:Button ID="btnEditSubmit" runat="server" Text="修改帳號" OnClick="btnEditSubmit_Click" ValidationGroup="SubmitValidation"/>
                    <% } %>
                </div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name" />
                        <asp:BoundField DataField="Age" HeaderText="年齡" SortExpression="Age" />
                        <asp:BoundField DataField="Birthday" HeaderText="生日" SortExpression="Birthday" />
                        <asp:CommandField ShowEditButton="true" ShowDeleteButton="true"/>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
</asp:Content>
