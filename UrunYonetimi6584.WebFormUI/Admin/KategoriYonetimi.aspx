<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="KategoriYonetimi.aspx.cs" Inherits="UrunYonetimi6584.WebFormUI.Admin.KategoriYonetimi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Kategori Yönetimi</h1>
    <asp:GridView ID="dgvKategoriler" runat="server"></asp:GridView>
    <table>
        <tr>
            <td>Kategori Adı</td>
            <td>
                <asp:TextBox ID="txtName" runat="server" required></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Açıklama</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Durum</td>
            <td>
                <asp:CheckBox ID="cbIsActive" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnEkle" runat="server" Text="Ekle" OnClick="btnEkle_Click" />
                <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" />
                <asp:Button ID="btnSil" runat="server" Text="Sil" />
            </td>
            <td></td>
        </tr>
    </table>
</asp:Content>
