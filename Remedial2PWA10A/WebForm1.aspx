<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Remedial2PWA10A.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <asp:Button ID="ButtonInsertar" runat="server" Text="Insertar Datos" OnClick="ButtonInsertar_Click" />
            <asp:Button ID="ButtonDejarInsertar" runat="server" Text="Dejar Insertar" OnClick="ButtonDejarInsertar_Click" Visible="false" />

            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" ShowFooter="true" OnRowCreated="GridView1_RowCreated">
              <Columns>
                <asp:BoundField DataField="Recibio" HeaderText="Recibio"/>
                <asp:BoundField DataField="Entrega" HeaderText="Entrega"/>
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"/>
                <asp:BoundField DataField="Fecha_Entre" HeaderText="Fecha_Entre"/>
                <asp:BoundField DataField="Precio" HeaderText="Precio"/>
                <asp:BoundField DataField="Id_Obra" HeaderText="ID_Obra"/>
                <asp:BoundField DataField="ID_Material" HeaderText="ID_Material"/>
                <asp:BoundField DataField="ID_Proveedor" HeaderText="ID_Proveedor"/>
                <asp:CommandField />
            </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
