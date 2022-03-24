<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactWiseContactCategoryList.aspx.cs" Inherits="AdminPanel_Contact_ContactWiseContactCategoryList" %>

<asp:Content ID="cHead" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="cContent" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container border my-4 p-4">
        <div class="row mb-2">
            <div class="col-md-6">
                <h2>
                    <i class="fas fa-user"></i>
                    Contact Wise Contact Category
                </h2>
            </div>
            <div class="col-md-6 d-flex justify-content-center">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
        </div>
        <div class="">
            <asp:GridView ID="gvContactWiseContactCategory" runat="server" AutoGenerateColumns="false" OnRowCommand="gvContactWiseContactCategory_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnDelete" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure, you want to delete contact wise contact category?');" CommandName="Delete" CommandArgument='<%# Eval("ContactWiseContactCategoryID").ToString() %>'>
                                <i class="fas fa-trash-alt"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category"/>
                </Columns>
            </asp:GridView>
        </div>
        <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= gvContactWiseContactCategory.ClientID %>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
            $('#<%= gvContactWiseContactCategory.ClientID %>').DataTable();
        });
        </script>
    </div>
</asp:Content>

