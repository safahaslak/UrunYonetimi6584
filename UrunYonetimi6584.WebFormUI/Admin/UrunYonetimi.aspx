<%@ Page Title="Ürün Yönetimi" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UrunYonetimi.aspx.cs" Inherits="UrunYonetimi6584.WebFormUI.Admin.UrunYonetimi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Ürün Yönetimi</h1>
    <asp:GridView ID="dgvUrunler" runat="server" CssClass="table table-striped table-hover" OnSelectedIndexChanged="dgvUrunler_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
        </Columns>
    </asp:GridView>

    <table>
        <tr>
            <td>Ürün Adı</td>
            <td>
                <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Marka</td>
            <td>
                <asp:TextBox ID="txtBrand" CssClass="form-control" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Stok</td>
            <td>
                <asp:TextBox ID="txtStock" TextMode="Number" required CssClass="form-control" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Fiyat</td>
            <td>
                <asp:TextBox ID="txtPrice" required CssClass="form-control" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Kategori</td>
            <td>
                <asp:DropDownList ID="cmbKategoriler" CssClass="form-select" runat="server" DataTextField="Name" DataValueField="Id"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Ürün Açıklaması</td>
            <td>
                <asp:TextBox ID="txtDescription" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Durum</td>
            <td>
                <asp:CheckBox ID="cbIsActive" CssClass="form-check" Text="Durum" runat="server" /></td>
        </tr>
        <tr>
            <td>Anasayfa</td>
            <td>
                <asp:CheckBox ID="cbIsHome" CssClass="form-check" Text="Göster" runat="server" /></td>
        </tr>
        <tr>
            <td>Ürün Resmi</td>
            <td>
                <asp:FileUpload ID="fuImage" CssClass="form-control" runat="server" />
                <asp:Image ID="Image" runat="server" />
                <asp:CheckBox ID="cbResmiSil" Text="Resmi Sil" runat="server" /></td>
                <asp:HiddenField ID="hfResim" runat="server" />
            </td>
        </tr>
        <tr class="mt-3">
            <td></td>
            <td>
                <asp:Button ID="btnEkle" runat="server" Text="Ekle" CssClass="btn btn-primary" OnClick="btnEkle_Click" />
                <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" CssClass="btn btn-success" OnClick="btnGuncelle_Click" Enabled="false" />
                <asp:Button ID="btnSil" runat="server" Text="Sil" CssClass="btn btn-danger" OnClick="btnSil_Click" Enabled="false" />
            </td>
        </tr>
    </table>

</asp:Content>
