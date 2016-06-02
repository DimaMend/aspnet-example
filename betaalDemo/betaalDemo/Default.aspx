<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="betaalDemo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #enduser {
            height: 143px;
            width: 298px;
            margin-right: 3px;
            margin-top: 5px;
            margin-bottom: 0px;
        }
        #enduserAdress {
            height: 54px;
            margin-left: 4px;
            margin-right: 0px;
            margin-top: 0px;
            margin-bottom: 0px;
            width: 363px;
        }
        .auto-style1 {
            width: 75px;
        }
        .auto-style2 {
            width: 155px;
        }
        .auto-style5 {
            width: 155px;
            height: 24px;
        }
        .auto-style7 {
            width: 155px;
            height: 17px;
        }
        .auto-style8 {
            height: 33px;
        }
        .auto-style9 {
            width: 153px;
            height: 17px;
        }
        .auto-style10 {
            width: 153px;
        }
        .auto-style11 {
            width: 153px;
            height: 24px;
        }
        .auto-style12 {
            width: 176px;
        }
        .auto-style13 {
            height: 33px;
            width: 176px;
        }
    </style>
</head>
<body style="height: 696px; width: 1451px; margin-left: 21px; margin-right: 0px; margin-top: 15px">
    <form id="form1" style="height: 548px; width: 1324px; margin-bottom: 0px; margin-left: 104px; margin-top: 34px;" runat="server" draggable="false">
        
        <table id="enduser" border="1" cellspacing="0" cellpadding="0" style="display: inline-block; float: left;">
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="Label1" runat="server" Text="Tussenvoegsel :"></asp:Label>
                 </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TxtTussen" runat="server"></asp:TextBox>
                </td>

            </tr>
                   <tr>
                <td class="auto-style10">
                    <asp:Label ID="Label2" runat="server" Text="Achternaam :"></asp:Label>
                 </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TxtAchternaam" runat="server"></asp:TextBox>
                </td>

            </tr>
                   <tr>
                <td class="auto-style10">
                    Tel.Nummer :</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TxtTel" runat="server"></asp:TextBox>
                </td>

            </tr>
                   <tr>
                <td class="auto-style10">
                    <asp:Label ID="Label4" runat="server" Text="Email :"></asp:Label>
                 </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                </td>

            </tr>
                   <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label5" runat="server" Text="IBAN :"></asp:Label>
                 </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TxtIban" runat="server"></asp:TextBox>
                </td>
            </tr>
       </table>
    
        <table id="enduserAdress" border="1" style="float:left;">
           <tr>
                <td class="auto-style12">
                    <asp:Label ID="Label6" runat="server" Text="Straatnaam :"></asp:Label>
                 </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TxtStraat" runat="server"></asp:TextBox></td><td><asp:Label ID="Label8" runat="server" Text="hr."></asp:Label><asp:TextBox ID="TxtHuisnummer" runat="server" Width="30px"></asp:TextBox>
                </td>
            </tr>
               <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label3" runat="server" Text="Postcode :"></asp:Label>
                 </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TxtPostcode" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label7" runat="server" Text="Stad :"></asp:Label>
                 </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TxtStad" runat="server"></asp:TextBox>
                </td>
            </tr>  
        </table>
    
        <asp:Button ID="BtnTransaction" runat="server" Text="Transactie" OnClick="Button1_Click" Height="55px" style="margin-left: 4px; margin-top: 0px; margin-bottom: 0px;clear:both;float:left" Width="168px" BorderStyle="Ridge" />   
            </form>
    
</body>
</html>
