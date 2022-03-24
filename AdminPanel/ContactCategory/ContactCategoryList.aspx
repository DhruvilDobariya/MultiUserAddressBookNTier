<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryList" %>

<asp:Content ID="cHead" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cContent" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container border my-4 p-4">
        <div class="row mb-2">
            <div class="col-md-4">
                <h2>
                    <i class="fas fa-users"></i>
                    Contact Category
                </h2>
            </div>
            <div class="col-md-4 d-flex justify-content-center">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <div class="col-md-4 d-flex justify-content-end p-2">
                <asp:HyperLink runat="server" ID="btnAddCountry" NavigateUrl="~/AdminPanel/ContactCategory/Add" CssClass="btn btn-danger">
                    <i class="fas fa-plus"></i>
                    Add Contact Category
                </asp:HyperLink>
            </div>
        </div>
        <asp:GridView ID="gvContactCategory" runat="server" CssClass="" AutoGenerateColumns="false" OnRowCommand="gvContactCategory_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID="hlEdit" NavigateUrl='<%# "~/AdminPanel/ContactCategory/Edit/" + EncryptionDecryption.Encode(Eval("ContactCategoryID").ToString().Trim()) %>' CssClass="btn btn-gradient">
                            <i class="fas fa-edit"></i>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnDelete" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure, you want to delete contact category?');" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactCategoryID").ToString() %>'>
                             <i class="fas fa-trash-alt"></i>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category"/>
                <asp:TemplateField HeaderText="CreationDate">
                    <ItemTemplate>
                        <%# Convert.ToDateTime(Eval("CreationDate").ToString()).ToShortDateString() %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= gvContactCategory.ClientID %>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
            $('#<%= gvContactCategory.ClientID %>').DataTable();
        });
    </script>
</asp:Content>

