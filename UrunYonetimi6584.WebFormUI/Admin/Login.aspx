﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UrunYonetimi6584.WebFormUI.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        html,
        body {
            height: 100%;
        }

        .form-signin {
            max-width: 330px;
            padding: 1rem;
        }

            .form-signin .form-floating:focus-within {
                z-index: 2;
            }

            .form-signin input[type="email"] {
                margin-bottom: -1px;
                border-bottom-right-radius: 0;
                border-bottom-left-radius: 0;
            }

            .form-signin input[type="password"] {
                margin-bottom: 10px;
                border-top-left-radius: 0;
                border-top-right-radius: 0;
            }
    </style>
</head>
<body class="d-flex align-items-center py-4 bg-body-tertiary">
    <main class="form-signin w-100 m-auto">
        <form id="form1" runat="server">
            <div class="text-center">
                <img class="mb-4" src="../Images/lockphoto.jpg" alt="" width="72">
                <h1 class="h3 mb-3 fw-normal">Lütfen Giriş Yapınız!</h1>
            </div>

            <div class="form-floating">
                <input type="email" class="form-control" id="floatingInput" runat="server" placeholder="name@example.com">
                <label for="floatingInput">Email</label>
            </div>
            <div class="form-floating">
                <input type="password" class="form-control" id="floatingPassword" runat="server" placeholder="Şifre">
                <label for="floatingPassword">Şifre</label>
            </div>

            <div class="form-check text-start my-3">
                <input class="form-check-input" type="checkbox" value="remember-me" id="flexCheckDefault">
                <label class="form-check-label" for="flexCheckDefault">
                    Beni Hatırla
                </label>
            </div>
            <asp:Button ID="btnGiris" runat="server" Text="Giriş" CssClass="btn btn-primary w-100 py-2" OnClick="btnGiris_Click" />
            
            <p class="mt-5 mb-3 text-body-secondary">© 2017–2023</p>
        </form>
    </main>
</body>
</html>
