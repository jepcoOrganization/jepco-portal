<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FileUpdate.ascx.cs" Inherits="Controls_FileUpdate" %>

<asp:HiddenField runat="server" ID="hdnFileNAme" />


<script>
    var GetFileNo = $("#ContentPlaceHolder1_ctl00_hdnFileNAme").val();
    console.log("File : ", GetFileNo)
</script>