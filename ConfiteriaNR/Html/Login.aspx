<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ConfiteriaNR.Http.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" name="viewport" />
    <title>Login</title>
    <link rel="icon" type="image/png" href="https://cdn3.iconfinder.com/data/icons/google-material-design-icons/48/ic_timer_auto_48px-512.png"/>
    <meta charset="utf-8" />
    <link href="https://fonts.googleapis.com/css?family=Lato:300,400,700&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link href="../Css/styleLogin.css" rel="stylesheet" />
</head>
<body id="body-Login">
    <section class="ftco-section" runat="server">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-7 col-lg-5 col-auto">
                    <div class="login-wrap p-5 p-md-4">
                        <div class="icon d-flex align-items-center justify-content-center">
                            <span class="fa fa-user-o"></span>
                        </div>
                        <h3 class="text-center mb-4">Iniciar Sesion</h3>
                        <form action="#" id="Formulario_Login" class="login-form" runat="server">
                            <div class="form-group">
                                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control rounded-left" placeholder="Ingresa tu usuario." required="required"></asp:TextBox>
                            </div>
                            <div class="form-group d-flex">
                                <asp:TextBox runat="server" ID="txtContraseña" TextMode="Password" CssClass="form-control rounded-left" placeholder="Ingresa tu contraseña." required="required"></asp:TextBox>
                            </div>
                            <hr />
                            <div class="form-group row">
                                <asp:Label ID="lblError" CssClass="alert-danger" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnIngresar" Text="Ingresar" type="submit" runat="server" class="form-control btn btn-primary rounded submit px-3" OnClick="Ingresar_Click" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <script src="js/jquery.min.js"></script>
    <script src="js/popperLogin.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>


</body>
</html>
