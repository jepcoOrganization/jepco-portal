<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SubmitCV.ascx.cs" Inherits="Controls_SubmitCV" %>
<%--<%@ Register Assembly="BotDetect" Namespace="BotDetect.Web.UI" TagPrefix="cc2" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<%@ Register Assembly="BotDetect" Namespace="BotDetect.Web.UI" TagPrefix="BotDetect" %>--%>

<section class="contact_part">
    <div class="message_help">
        <div class="container">

            <h1>Submit Your CV</h1>
            <div class="row">
                <div class="col-xl-12 col-lg-12 col-md-12">


                    <div class="row">
                        <div class="col-xl-6 col-lg-6 col-md-6">
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="txtName" placeholder="Add your full name" ClientIDMode="Static" CssClass="customClick"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-xl-6 col-lg-6 col-md-6">
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="txtEmail" placeholder="Add your email address" ClientIDMode="Static" CssClass="customClick"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xl-6 col-lg-6 col-md-6">
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="txtMobile" placeholder="Enter your phone number" ClientIDMode="Static" CssClass="customClick mobileNo"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-xl-6 col-lg-6 col-md-6">
                            <div class="form-group">
                                <asp:DropDownList ID="ddlInterest" runat="server" class="customClick" TabIndex="2" Width="100%">
                                    <asp:ListItem Value="Full Time" Text="Full Time"></asp:ListItem>
                                    <asp:ListItem Value="Internship" Text="Internship"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-xl-6 col-lg-6 col-md-6">
                            <div class="form-group">
                                <label>Upload Your CV</label>
                                <div class="file-upload-wrapper" data-text="Select your file!">
                                    <span runat="server" id="spanBro_1" name="spanBro_1"></span><%--onchange="callme2(this,1)"--%>
                                    <input name="fileuploadfield_1" id="fileuploadfield_1" type="file" class="file-upload-field" value="Browse">
                                </div>
                            </div>
                        </div>
                       <%-- <div class="col-xl-6 col-lg-6 col-md-6">
                            <BotDetect:WebFormsCaptcha ID="ExampleCaptcha" UserInputID="CaptchaCode" runat="server" />
                            <asp:TextBox ID="CaptchaCode" runat="server" />
                        </div>--%>
                        <div class="row">
                      <div class="col-xl-12 col-lg-12 col-md-12">
                                 
                                   <table>
                                                    <tr>
                                                        <td style="height: 50px; width: 100px;">
                                                            <asp:Image ID="imgCaptcha" runat="server" />
                                                        </td>
                                                      
                                                    </tr>
                                                </table>
                                     <div class="form-group">
                                         <asp:TextBox ID="txtCaptcha" runat="server" Width="200px" PlaceHolder="Enter Captcha"></asp:TextBox>
                                         </div>
                                         <asp:Label ID="CaptchaErrorLabel" runat="server" ForeColor="Red" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCaptcha" ValidationGroup="1" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Required Field</asp:RequiredFieldValidator>
                               </div>
                                     
                            </div>
                 
                        <div class="col-xl-6 col-lg-6 col-md-6">
                            <button class="career_send_msg_btn" onclick="validForm();" type="button">Send message</button>
                        </div>
                            
                    </div>
                    <asp:Button runat="server" ID="lnkSubmitFrm" OnClick="lnkSubmitFrm_Click" Text="Send message" Style="display: none;" disbled="disabled"></asp:Button>
                    <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
            </div>

            <div class="clearfix"></div>
        </div>
    </div>
</section>
<asp:LinkButton ID="lnkInquiry" runat="server"></asp:LinkButton>
<cc1:ModalPopupExtender runat="server" ID="mpeInquiry"
    TargetControlID="lnkInquiry" BehaviorID="mpeInquiry"
    BackgroundCssClass="modalBackground" PopupControlID="panelInqiry"
    CancelControlID="btnCloseInq">
</cc1:ModalPopupExtender>
<asp:Panel ID="panelInqiry" runat="server" CssClass="modalPopup d_model_popup l_modelpopup" Style="display: none">
    <div class="modal-dialog modal-md">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-body">
                <asp:LinkButton CssClass="close" data-dismiss="modal" runat="server" ID="btnCloseInq">&times;</asp:LinkButton>
                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeEn/img/logo.png" />
                <div class="divContent">
                    <strong>
                        <asp:Literal runat="server" ID="lblInqTitle" Text="Message"></asp:Literal>
                    </strong>
                    <p>
                        <asp:Literal runat="server" ID="lblInqMessage">                             
                        </asp:Literal>
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Panel>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

<script>    
    $(".customClick").keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            $("[id*=<%=lnkSubmitFrm.ClientID %>]").click();
        }
    });
    var fileSize = 0;
    function validForm() {
        debugger;
        var vname = false;
        var vEmail = false;
        var vMobile = false;
        var vFile = false;
        if ($("#txtName").val() != "") {
            $("#txtName").css('border', '1px solid #e3e3e3;');
            vname = true;
        }
        else {
            $("#txtName").css('border', '1px solid red');
        }
        if ($("#txtEmail").val() != "") {
            var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            if (!regex.test($("#txtEmail").val())) {
                $("#txtEmail").css('border', '1px solid red');
            } else {
                $("#txtEmail").css('border', '1px solid #e3e3e3;');
                vEmail = true;
            }
        }
        else {
            $("#txtEmail").css('border', '1px solid red');
        }
        if ($("#txtMobile").val() != "") {
            $("#txtMobile").css('border', '1px solid #e3e3e3;');
            vMobile = true;
        }
        else {
            $("#txtMobile").css('border', '1px solid red');
        }

        //-------------------- Valid file value ----------------------
        if ($("#fileuploadfield_1").val() != "") {
            var ext = $("#fileuploadfield_1").val().split('.').pop();
            //if (ext.toLowerCase() == "pdf" || ext.toLowerCase() == "doc" || ext.toLowerCase() == "docx") {
            //    $("#fileuploadfield_1").css('border', '1px solid #e3e3e3;');
                
            //}
            //else {
            //    $("#fileuploadfield_1").css('border', '1px solid #ff0000');
            //    alert("Kindly upload .pdf or .doc or .docx file with 2MB size");
            //}
             $("#fileuploadfield_1").css('border', '1px solid #e3e3e3;');
            vFile = true;
        }
        else {
            $("#fileuploadfield_1").css('border', '1px solid #ff0000');
        }

        if (vname && vEmail && vMobile && vFile) {
            $("[id*=<%=lnkSubmitFrm.ClientID %>]").click();
        }
    }

    $('#fileuploadfield_1').bind('change', function () {
        if (this.files[0].size > 2097152) {
            alert("Kindly upload maximum 2MB file");
            $(this).val("");
        }
        else {
            var ext = $(this).val().split('.').pop();
            if (ext.toLowerCase() == "pdf" || ext.toLowerCase() == "doc" || ext.toLowerCase() == "docx") {
            }
            else {
                alert("Kindly upload .pdf or .doc or .docx file with 2MB size");
                 $(this).val("");
            }
            fileSize = this.files[0].size;
        }
    });
</script>

<script>

    $(".mobileNo").keypress(function (e) {

        //if the letter is not digit then display error and don't type anything
        if (e.which !== 8 && e.which !== 0 && (e.which < 48 || e.which > 57)) {
            //display error message
            //$("#errmsg").html("Digits Only").show().fadeOut("slow");

            return false;
        }
        else {
            var len = $(".mobileNo").val().length;
            //if (len > 10)
            //{
            //    return false;
            //}
        }

    });


</script>
