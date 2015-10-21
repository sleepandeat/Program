<%@ Page Language="C#" AutoEventWireup="true" Inherits="DotNetTextBox.UpLoad" %>
<%@ Import Namespace="DotNetTextBox" %>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<base target="_self" />
<script language="javascript" type="text/javascript">
var userAgent = navigator.userAgent.toLowerCase();
var is_ie = (userAgent.indexOf('msie') != -1);
var image = new Array;
var w,h;

function reloadClick()
{
var reload=document.getElementById ("reload");
reload.click();
}

function changeWaterMark(type)
{
if(type=='watermark')
{
if(document.getElementById("watermark").checked)
{
document.getElementById("watermarkText").checked=false;
document.getElementById("config_watermark").value="false";
document.getElementById("config_watermarkImages").value="true";
}
else
{
document.getElementById("config_watermarkImages").value="false";
}

}
else
{
if(document.getElementById("watermarkText").checked)
{
document.getElementById("watermark").checked=false;
document.getElementById("config_watermark").value="true";
document.getElementById("config_watermarkImages").value="false";
}
else
{
document.getElementById("config_watermark").value="false";
}

}

}

function loading() 
{
    document.getElementById("loading").style.visibility="visible";
    return true;
}

function checksize(str,type)
{
    if(type=="wedth"&document.getElementById("ImgWidth").value!=""&document.getElementById("ImgHeight").value!="")
    {
       if(w!=null&&h!=null)
       {
       document.getElementById("ImgHeight").value=Math.round((parseInt(str)*h)/w);
       }
       else
       {
       w=str;
       h=document.getElementById("ImgHeight").value;
       }
    }
    else if(document.getElementById("ImgWidth").value!=""&document.getElementById("ImgHeight").value!="")
    {
       if(w!=null&&h!=null)
       {
       document.getElementById("ImgWidth").value=Math.round((parseInt(str)*w)/h);
       }
       else
       {
       w=document.getElementById("ImgWidth").value;
       h=str;
       }
    }
}

function preview(name) 
{
    
    if(is_ie)
    {
    var path=document.getElementById("path").innerText;
    }
    else
    {
    var path=document.getElementById("path").textContent;
    }
    document.getElementById("file_path").value=path+name.replace(/\s/g,"\%20");
    document.getElementById("previewImg").innerHTML='<img src='+document.getElementById("file_path").value+' align="middle" onload="ImgWidth.value=this.width;ImgHeight.value=this.height;w=this.width;h=this.height;if(this.width>300){this.width=300;this.height=this.width*0.75}" />';
    document.getElementById("file_path").focus();
}

function newImages() 
{
    if(document.getElementById("file_path").value!="")
    {
    var arr=new Array;
    arr[0]=document.getElementById("file_path").value
    arr[1]=document.getElementById("ImgWidth").value;
    arr[2]=document.getElementById("ImgHeight").value;
    arr[3]=document.getElementById("ImgAlt").value;
    arr[4]=document.getElementById("Imgalign").value;
    if(is_ie)
    {
    window.returnValue = arr;
    }
    else
    {
    if(document.getElementById("insertImg").value!='<%=ResourceManager.GetString("mof")%>')
    {
    window.opener.inserObject(null,'img',arr);
    }
    else
    {
    window.opener.inserObject(null,'modimg',arr);
    }
    }
    }
    window.close();
}

var sTitle='<%=ResourceManager.GetString("insertimages")%>';
if(is_ie)
{
if (dialogArguments!=null)
sTitle='<%=ResourceManager.GetString("mofimages")%>';
}
else
{
image=window.opener.GetImg();
if(image[0]!=null)
{
sTitle='<%=ResourceManager.GetString("mofimages")%>';
}
window.focus();
}
document.write("<TITLE>" + sTitle + "</TITLE>");
</script>
<link href="stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body topmargin="0">
    <form id="uploadFace" runat="server">
        <table border="0" align="center" style="word-break:break-all" width="100%">
            <tr>
                <td colspan="4" rowspan="1" valign="top" style="width: 840px">
                    <fieldset><legend><span style="color: gray"><%=ResourceManager.GetString("uploadface")%></span>&nbsp;</legend>
        <%=ResourceManager.GetString("uploadpath")%>：<asp:Label ID="path" runat="server" ForeColor="Black"></asp:Label><br />
        <%=ResourceManager.GetString("uploadimages")%>：<asp:FileUpload ID="FileUpload1" runat="server" Width="388px" Height="21px" TabIndex="2" Font-Size="10pt" /><asp:Button ID="uploadBtn" runat="server" OnClientClick="loading()" OnClick="UploadBtn_Click"/><asp:TextBox ID="remoteurl" runat="server" Visible="False" Text="http://" Width="350px"></asp:TextBox>
                        <asp:Button ID="remoteupload" runat="server" Visible="False" Width="49px" OnClientClick="loading()" OnClick="remoteupload_Click" /><br />
        <%=ResourceManager.GetString("filepath")%>：<asp:TextBox ID="file_path" runat="server" Width="316px" TabIndex="1"></asp:TextBox>
        <input language="javascript" onclick="javascript:newImages()" type="button" value='<%=ResourceManager.GetString("insertimage")%>' id="insertImg" /><br />
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                            <asp:ListItem Selected=True Value="local" />
                            <asp:ListItem Value="remote" />
                        </asp:RadioButtonList>[ <%=ResourceManager.GetString("uploaduse")%>：<asp:label ID="useSpace" ForeColor="Red" runat=server />，<%=ResourceManager.GetString("have")%>：<asp:label ID="space" ForeColor="Red" runat=server /><%=ResourceManager.GetString("singlesize")%>：<asp:Label ID="maxSingleUploadSize" runat="server" ForeColor="Red"></asp:Label>
    ]</fieldset>
                    <fieldset style="text-align: center"><legend><span style="color: gray"><%=ResourceManager.GetString("filelist")%></span>&nbsp;</legend>
        <div style="border-right: 1.5pt inset; border-top: 1.5pt inset; vertical-align: middle;
            overflow: auto; border-left: 1.5pt inset; width: 100%; border-bottom: 1.5pt inset;
            height: 240px; background-color: white">
<asp:GridView runat="server" id="File_List" HeaderStyle-HorizontalAlign=Center AutoGenerateColumns="False" HeaderStyle-BackColor="buttonface" HeaderStyle-ForeColor=windowtext HeaderStyle-Font-Bold="True" Width="100%" BorderWidth="1px" OnRowCancelingEdit="File_List_RowCancelingEdit" OnRowUpdating="File_List_RowUpdating">
  <Columns>
  <asp:TemplateField>
        <HeaderTemplate>
                <asp:CheckBox ID="checkall" runat="server" Text=<%#ResourceManager.GetString("selectall")%> AutoPostBack="true" OnCheckedChanged="checkAll" />
         </HeaderTemplate>
          <ItemTemplate>
                   <asp:CheckBox ID="check" runat="server" />
            </ItemTemplate>     
            <ItemStyle HorizontalAlign="Center" Width="55px" />
</asp:TemplateField>
    <asp:TemplateField>
    <EditItemTemplate>
    <asp:TextBox ID="editName" Text=<%#DataBinder.Eval(Container.DataItem,"Name").ToString().Replace(DataBinder.Eval(Container.DataItem,"Extension").ToString(),string.Empty)%> Width="100px" runat=server></asp:TextBox> <asp:Button ID="editBtn" CommandName="Update" CommandArgument=<%#DataBinder.Eval(Container.DataItem,"Name")%> runat=server Text=<%#ResourceManager.GetString("edit")%> /> <asp:Button ID="Cancel" runat=server Text=<%#ResourceManager.GetString("cancel")%> CommandName="Cancel" />
    </EditItemTemplate>
    <ItemTemplate>
    <asp:Label ID="ListID" Text=<%#DataBinder.Eval(Container.DataItem,"Name")%> style="cursor:pointer; word-break:break-all" onmouseout="this.style.textDecoration='none'" onmouseover="this.style.textDecoration='underline'" onclick="<%#&quot;javascript:preview('&quot; + DataBinder.Eval(Container.DataItem,&quot;Name&quot;) + &quot;')&quot;%>"  runat=server />
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="LastWriteTime" ReadOnly="True" HtmlEncode=False DataFormatString="{0:D}" >
        <ItemStyle HorizontalAlign="Center" Width="25%" />
    </asp:BoundField>
    <asp:BoundField DataField="Length" ReadOnly="True" HtmlEncode=False DataFormatString="{0:#,### Bytes}" >
        <ItemStyle HorizontalAlign=Center Width="25%" />
    </asp:BoundField>
  </Columns>
<HeaderStyle Font-Bold="True" ForeColor="WindowText" BackColor="Control" BorderWidth="1px" HorizontalAlign="Center" />
</asp:GridView></div>
                <fieldset><legend><span style="color: dimgray"><span style="color: gray"><%=ResourceManager.GetString("imagepreview")%></span>&nbsp;</span></legend>
                    <table height="100%" width="100%">
                        <tr>
                            <td colspan="3" rowspan="3" style="height: 252px">
                                <div style="border-right: 1.5pt inset; padding-right: 0px; border-top: 1.5pt inset;
                                    padding-left: 0px; padding-bottom: 0px; vertical-align:middle; overflow: auto;
                                    border-left: 1.5pt inset; width: 320px; padding-top: 2px; border-bottom: 1.5pt inset;
                                    height: 235px; background-color: white">
                                    <div id="previewImg" align="center" style="background-color: white">
                                    </div>
                                </div></td>
                            <td colspan="1" rowspan="3" valign="top" style="height: 252px"><%=ResourceManager.GetString("width")%>：<input id="ImgWidth" style="width: 97px" onblur="if(document.getElementById('checkimgsize').checked){checksize(this.value,'wedth');}" type="text" maxlength="10" /><br />
                                <br />
                                <%=ResourceManager.GetString("height")%>：<input id="ImgHeight" style="width: 97px" type="text" onblur="if(document.getElementById('checkimgsize').checked){checksize(this.value,'height');}" maxlength="10" /><br /><input id="checkimgsize" type="checkbox" checked="CHECKED" />&nbsp;<%=ResourceManager.GetString("keepratio")%><br />
                                <%=ResourceManager.GetString("alt")%>：<input id="ImgAlt" style="width: 97px" type="text" maxlength="100" /><br />
                                <br />
                                <%=ResourceManager.GetString("align")%>：<select id="Imgalign" style="width: 97px">
                                    <option selected="selected" value=""><%=ResourceManager.GetString("default")%></option>
                                    <option value="left"><%=ResourceManager.GetString("left")%></option>
                                    <option value="center"><%=ResourceManager.GetString("center")%></option>
                                    <option value="right"><%=ResourceManager.GetString("right")%></option>
                                </select><br />
                                <br />
                                <%=ResourceManager.GetString("watermark")%><input id="watermark" onclick="changeWaterMark('watermark')" type="checkbox" />
                                X：<asp:TextBox runat=server id="inputx" style="width: 40px" maxlength="4" >0</asp:TextBox>&nbsp;<br />
                                <br />
                                <%=ResourceManager.GetString("watermarkText")%><input id="watermarkText" onclick="changeWaterMark('watermarkText')" type="checkbox" />
                                Y：<asp:TextBox runat=server id="inputy" style="width: 40px" maxlength="4" >0</asp:TextBox><br />
                                <br /><a href="#" onclick="if(is_ie){showModalDialog('Advanced.aspx',window,'dialogWidth:800px;dialogHeight:600px;status:0;scroll:yes');reload.click();}else{window.open('Advanced.aspx');}">
                                <%=ResourceManager.GetString("advancedsetting")%></a><a id='reload' href='uploadimg.aspx' style='display:none'></a></td>
                        </tr>
                    </table>
                </fieldset>
                <table width="100%" border="0px"><tr><td height="40">
                    [<%=ResourceManager.GetString("controlmenu")%>]：<asp:button id="selectAllBtn" runat="server"  borderstyle="Dashed" onclick="selectAllBtn_Click" ></asp:button>
                        <asp:Button ID="deleteBtn" runat="server" BorderStyle="Dashed" OnClick="deleteBtn_Click" />&nbsp;<asp:button id="editBtn" runat="server" borderstyle="Dashed" onclick="editBtn_Click" ></asp:button>
                    <input language="javascript" onclick="if(is_ie){showModalDialog('find.aspx',this,'dialogWidth:320px;dialogHeight:130px;status:0;scroll:no');}else{window.find();}"
                            type="button" value='<%=ResourceManager.GetString("findfile")%>' />
                    <input language="javascript" onclick="window.close();" type="button" value="<%=ResourceManager.GetString("close")%>" /></td>
    <td align="right">
        <a href="http://www.aspxcn.com.cn" target=_blank><img border=0px src="img/logo_S.png" /></a></td>
</tr></table>
                        </fieldset>
        <asp:HiddenField ID="config_watermark" runat="server" />
        <asp:HiddenField ID="config_watermarkText" runat="server" />
        <asp:HiddenField ID="config_watermarkImages" runat="server" />
        <asp:HiddenField ID="config_watermakOption" runat="server" />
        <asp:HiddenField ID="config_watermarkImages_path" runat="server" />
        <asp:HiddenField ID="config_smallImages" runat="server" />
        <asp:HiddenField ID="config_smallImagesName" runat="server" />
        <asp:HiddenField ID="config_maxAllUploadSize" runat="server" />
        <asp:HiddenField ID="config_autoname" runat="server" />
        <asp:HiddenField ID="config_allowUpload" runat="server" />
        <asp:HiddenField ID="config_fileFilters" runat="server" />
        <asp:HiddenField ID="config_maxSingleUploadSize" runat="server" />
        <asp:HiddenField ID="config_fileListBox" runat="server" />
        <asp:HiddenField ID="config_watermarkImagesName" runat="server" />
        <asp:HiddenField ID="config_watermarkName" runat="server" />
        <asp:HiddenField ID="config_smallImagesType" runat="server" />
        <asp:HiddenField ID="config_smallImagesW" runat="server" />
        <asp:HiddenField ID="config_smallImagesH" runat="server" />
        <asp:HiddenField ID="config_type" Value="Images" runat="server" />
                    &nbsp;</td>
            </tr>
        </table>
        <div id="loading" style="border-right: #333333 1px dashed; border-top: #333333 1px dashed;
                        font-size: 9pt; visibility: hidden; border-left: #333333 1px dashed;
                        width: 270px; color: #000000; border-bottom: #333333 1px dashed; position: absolute; height: 120px; background-color: #ffffff">
                        <center>
                            <br />
                            <br />
                            <%=ResourceManager.GetString("loading")%></center>
                        <br />
                        <center>
                            <asp:Button ID="canceloading" runat="server" Style="border-top-style: dashed; border-right-style: dashed;
                                border-left-style: dashed; border-bottom-style: dashed" />&nbsp;</center>
                        <br />
                    </div>
<script type="text/javascript">
var load=document.getElementById('loading');
resizeLoad();
window.setInterval("resizeLoad()",10);
function resizeLoad()
{
load.style.top = parseInt((document.body.clientHeight-load.offsetHeight)/2+document.body.scrollTop);
load.style.left = parseInt((document.body.clientWidth-load.offsetWidth)/2+document.body.scrollLeft);
}

if(is_ie)
{
document.body.bgColor="ButtonFace";
if (dialogArguments!=null)
{
image = dialogArguments;
document.getElementById("ImgWidth").value=image[0];
w=image[0];
h=image[1];
document.getElementById("ImgHeight").value=image[1];
document.getElementById("ImgAlt").value=image[2];
document.getElementById("file_path").value=image[3];
document.getElementById("Imgalign").value=image[4];
document.getElementById("insertImg").value='<%=ResourceManager.GetString("mof")%>';
document.getElementById("previewImg").innerHTML='<img src='+image[3]+' align="middle" onload="if(this.width>300){this.width=300;this.height=this.width*0.75}" />';
}
}
else
{
document.body.bgColor="#E0E0E0";
if(image[0]!=null)
{
document.getElementById("ImgWidth").value=image[0];
document.getElementById("ImgHeight").value=image[1];
document.getElementById("ImgAlt").value=image[2];
document.getElementById("file_path").value=image[3];
document.getElementById("Imgalign").value=image[4];
document.getElementById("insertImg").value='<%=ResourceManager.GetString("mof")%>';
document.getElementById("previewImg").innerHTML='<img src='+image[3]+' align="middle" onload="if(this.width>300){this.width=300;this.height=this.width*0.75}" />';
}
}

if(document.getElementById("config_watermarkImages").value.toLowerCase()=="true")
{
document.getElementById("watermark").checked=true;
}

if(document.getElementById("config_watermark").value.toLowerCase()=="true")
{
document.getElementById("watermarkText").checked=true;
}

if(document.getElementById("config_watermakOption").value.toLowerCase()=="off")
{
document.getElementById("watermarkText").disabled=true;
document.getElementById("watermark").disabled=true;
document.getElementById("inputx").disabled=true;
document.getElementById("inputy").disabled=true;
}
</script>      
</form>
</body>
</html>