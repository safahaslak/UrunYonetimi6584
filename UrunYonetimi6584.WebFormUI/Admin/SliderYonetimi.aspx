<%@ Page Title="Slider Yönetimi" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SliderYonetimi.aspx.cs" Inherits="UrunYonetimi6584.WebFormUI.Admin.SliderYonetimi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Slider Yönetimi</h1>
    <asp:GridView ID="dgvSlider" runat="server" CssClass="table table-striped table-hover" OnSelectedIndexChanged="dgvSlider_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
        </Columns>
    </asp:GridView>
    <table>
        <tr>
            <td>Başlık</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Açıklama</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Resim</td>
            <td>
                <asp:FileUpload ID="fuImage" runat="server" />
                <asp:Image ID="Image1" runat="server" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnEkle" runat="server" Text="Ekle" CssClass="btn btn-primary" OnClick="btnEkle_Click"/>
                <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" CssClass="btn btn-success" OnClick="btnGuncelle_Click"/>
                <asp:Button ID="btnSil" runat="server" Text="Sil" CssClass="btn btn-danger"/>
            </td>
        </tr>
    </table>
</asp:Content>
