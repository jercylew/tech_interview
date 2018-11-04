<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact Us.aspx.cs" Inherits="TestWeb.Contact_Us" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 111px;
            width: 314px;
        }

        body {font-family: Arial, Helvetica, sans-serif;}
        * {box-sizing: border-box;}

        input[type=text], select, textarea {
            padding: 12px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
            margin-top: 6px;
            margin-bottom: 16px;
            resize: vertical;
        }

        input[type=submit] {
            background-color: #2471A3; /* #4CAF50 */
            color: white;
            padding: 12px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        input[type=submit]:hover {
            background-color: #45a049;
        }

        .container {
            border-radius: 5px;
            background-color: #f2f2f2;
            padding: 20px;
        }
    </style>
</head>
<body style="height: 172px">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="m_lblFrom" for="m_txtFrom" runat="server" Text="FROM"></asp:Label>
            <asp:TextBox ID="m_txtFrom" runat="server" Width="169px" Height="22px" placeholder="example@domain.com"></asp:TextBox>
        </div>
        <p>
            <asp:TextBox id="m_txtContent" TextMode="multiline" Columns="50" Rows="5" placeholder="Enter your comment here ..." runat="server" /></p>
        <asp:Button ID="m_btnSend" runat="server" OnClick="Button1_Click" Text="Send" />
        <asp:Label ID="m_lblSendStatus" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
