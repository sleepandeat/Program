// JScript 文件

String.prototype.trim = function() 
{ 
    return this.replace(/(^\s*)|(\s*$)/g, ""); 
} 

String.prototype.ltrim = function() 
{ 
    return this.replace(/(^\s*)/g, ""); 
} 

String.prototype.rtrim = function() 
{ 
    return this.replace(/(\s*$)/g, ""); 
}
String.prototype.len=function()
{
		return this.replace(/[^\x00-\xff]/g, "**").length;
}
String.prototype.replaceAll  = function(s1,s2){    
	return this.replace(new RegExp(s1,"gm"),s2);    
}  
function CheckAccount(str)
{
    	var patrn=/^([a-zA-Z0-9]|[._]|[\u0391-\uFFE5]){2,20}$/;  
			if (!patrn.exec(str)) 
				return false  
			return true 
}
function ReplaceSplit(str)
{
	str = str.trim();
	var p = /\r\n/g;

	return str.replace(p, "@%@"); 
}
function DeReplaceSplit(str)
{
	str = str.trim();
	var p = /@%@/g;
	return str.replace(p, "\r\n"); 
}
function CheckCard(str)
{
	str = str.trim();
	var p = /^([A-Za-z0-9,]|[-])+$/;
	return p.test(str);
}
function CheckQQ(str)
{
    	var patrn=/^[1-9][0-9]{4,}$/;
			if (!patrn.exec(str)) 
				return false  
			return true 
}
function CheckNumber(str)
{
    	var patrn=/^\d+$/;   
			if (!patrn.exec(str)) 
				return false  
			return true 
}

function CheckFloat(str)
{
			var patrn = /^\d+(\.\d+)?$/;
    	//var patrn=/^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$/;
			if (!patrn.exec(str)) 
				return false  
			return true 
}

function CheckUrl(str)
{
    var patrn=/^http:\/\/([\w\d\-]+\.)+[\w\d\-]+\/?/;
    if(!patrn.exec(str))
    return false
    return true;
}

function CheckMoney(str)
{
		if(!CheckFloat(str))
				return false;
		else
		{
				var money = parseFloat(str);
				return money >= 0.0;
		}
}

// JScript 文件
function $()
{ 
	var elements = new Array(); 
	for (var i = 0; i < arguments.length; i++)
	{ 
		var element = arguments[i]; 
		if (typeof element == 'string') 
			element = document.getElementById(element); 
		if (arguments.length == 1) 
			return element; 
		elements.push(element); 
	} 
	return elements; 
}

function f_EnterToTab(){
	if ( window.event.keyCode == 13 ){
		if (window.event.srcElement.type.toLowerCase() == "button")
			window.event.keyCode = 20;
		else
			window.event.keyCode = 9;
	}
}

/* 去掉html标记，留下文本信息*/
function filterHMTLText(s)
{
	//return strip_tags(s);
	var reg = /<[^>]+>/g;
	return s.replace(reg,"");
}
		
//验证信息;
//空字符值; 
function isEmpty(s){
	s = s.trim(); 
	return s.length == 0; 
}
//Email;
function isEmail(s){
	//s = s.trim(); //wjy1221修改
 	var p = /^[_\.0-9a-z-]+@([0-9a-z][0-9a-z-]+\.){1,4}[a-z]{2,3}$/i;
 	return p.test(s);
}
//数字; 
function isNumber(s){
	return !isNaN(s); 
}
//颜色值; 
function isColor(s){ 
	s = s.trim(); 
	if (s.length !=7) return false; 
	return s.search(/\#[a-fA-F0-9]{6}/) != -1; 
}
//手机号码; 
function isMobile(s){ 
	//s = s.trim(); 
	var p = /^\d{11,12}$/;
	return p.test(s);
}
//身份证;
function isCard(s){ 
	s = s.trim(); 
	var p = /^\d{15}(\d{2}[xX0-9])?$/; 
	return p.test(s);
}
//URL;
function isURL(s){
	s = s.trim().toLowerCase();
	var p = /^http:\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/;
	return p.test(s);
}
//Phone;
function isPhone(s){
	var p = /^((\(\d{3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}$/;
	return p.test(s.trim());
}
//Phone;排除7~8位的号码
function isPhoneNew(s){
	var p = /^((\(\d{3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)[1-9]\d{6,7}$$/;
	return p.test(s.trim());
}
//Zip;
function isZip(s){
	s = s.trim();
	var p = /^[1-9]\d{5}$/;
	return p.test(s);
}
//Double;
function isDouble(s){
	s = s.trim();
	var p = /^[-\+]?\d+(\.\d+)?$/;
	return p.test(s);
}
//date;
function isDate(s){
	s = s.trim();
	var p = /^\d{4}[.|-]\d{2}[.|-]\d{2}$/;
	return p.test(s);
}
//Integer;
function isInteger(s){
	s = s.trim();
	var p = /^[-\+]?\d+$/;
	return p.test(s);
}
//English;
function isEnglish(s){
	s = s.trim();
	var p = /^[A-Za-z]+$/;
	return p.test(s);
}
//中文;
function isChinese(s){
	var p = /^[\u0391-\uFFE5]+$/;
	return p.test(s.trim());
}
//双字节
function isDoubleChar(s){
	var p = /^[^\x00-\xff]+$/;
	return p.test(s);
}
//含有中文字符
function hasChineseChar(s){
	var p = /[^\x00-\xff]/;
	return p.test(s);
}
function hasAccountChar(s){
	var p = /^[^%?&:,'$\|\s]{0,40}$/;
	return p.test(s);
}
function limitLen(s,Min,Max){
	s=s.trim();
	if(s=="") return false;
	var slength=getLen(s);
	if((slength<Min)||(slength>Max)){
		return false;}
	else{
		return true;
		}
}

function inputMoney()
{
	if (event.keyCode!=46 && (event.keyCode<48 || event.keyCode>57)) 
		event.returnValue=false
}

function inputFloat()
{
	if (event.keyCode!=46 && (event.keyCode<48 || event.keyCode>57)) 
		event.returnValue=false
}

//Add By Swollaw In 20080725 For Check Int
function regInput(obj, reg, inputStr)
{
    var docSel = document.selection.createRange()   
    if (docSel.parentElement().tagName != "INPUT") return false   
    oSel = docSel.duplicate()   
    oSel.text = ""   
    var srcRange = obj.createTextRange()   
    oSel.setEndPoint("StartToStart", srcRange)   
    var str = oSel.text + inputStr + srcRange.text.substr(oSel.text.length)   
    return reg.test(str)   
}

function inputInt()
{
	if (event.keyCode<48 || event.keyCode>57) 
		event.returnValue=false
}

function CheckRepeat(arr)
{
	return /(\x0f[^\x0f]+\x0f)[\s\S]*\1/g.test("\x0f"+arr.join("\x0f\x0f")+"\x0f");
}

//格式化数字显示方式，也可以用于对数字重定精度。
/*
测试
alert(formatNumber(0,''));
alert(formatNumber(12432.21,'#,###'));
alert(formatNumber(12432.21,'#,###.000#'));
alert(formatNumber(12432,'#,###.00'));
alert(formatNumber('12432.415','#,###.0#'));
*/
function formatNumber(number,pattern){
    var str            = number.toString();
    var strInt;
    var strFloat;
    var formatInt;
    var formatFloat;
    if(/\./g.test(pattern)){
        formatInt        = pattern.split('.')[0];
        formatFloat        = pattern.split('.')[1];
    }else{
        formatInt        = pattern;
        formatFloat        = null;
    }

    if(/\./g.test(str)){
        if(formatFloat!=null){
            var tempFloat    = Math.round(parseFloat('0.'+str.split('.')[1])*Math.pow(10,formatFloat.length))/Math.pow(10,formatFloat.length);
            strInt        = (Math.floor(number)+Math.floor(tempFloat)).toString();                
            strFloat    = /\./g.test(tempFloat.toString())?tempFloat.toString().split('.')[1]:'0';            
        }else{
            strInt        = Math.round(number).toString();
            strFloat    = '0';
        }
    }else{
        strInt        = str;
        strFloat    = '0';
    }
    if(formatInt!=null){
        var outputInt    = '';
        var zero        = formatInt.match(/0*$/)[0].length;
        var comma        = null;
        if(/,/g.test(formatInt)){
            comma        = formatInt.match(/,[^,]*/)[0].length-1;
        }
        var newReg        = new RegExp('(\\d{'+comma+'})','g');

        if(strInt.length<zero){
            outputInt        = new Array(zero+1).join('0')+strInt;
            outputInt        = outputInt.substr(outputInt.length-zero,zero)
        }else{
            outputInt        = strInt;
        }

        var 
        outputInt            = outputInt.substr(0,outputInt.length%comma)+outputInt.substring(outputInt.length%comma).replace(newReg,(comma!=null?',':'')+'$1')
        outputInt            = outputInt.replace(/^,/,'');

        strInt    = outputInt;
    }

    if(formatFloat!=null){
        var outputFloat    = '';
        var zero        = formatFloat.match(/^0*/)[0].length;

        if(strFloat.length<zero){
            outputFloat        = strFloat+new Array(zero+1).join('0');
            //outputFloat        = outputFloat.substring(0,formatFloat.length);
            var outputFloat1    = outputFloat.substring(0,zero);
            var outputFloat2    = outputFloat.substring(zero,formatFloat.length);
            outputFloat        = outputFloat1+outputFloat2.replace(/0*$/,'');
        }else{
            outputFloat        = strFloat.substring(0,formatFloat.length);
        }

        strFloat    = outputFloat;
    }else{
        if(pattern!='' || (pattern=='' && strFloat=='0')){
            strFloat    = '';
        }
    }

    return strInt+(strFloat==''?'':'.'+strFloat);
}

function CopyText(txt)
{
	//window.clipboardData.setData('text',text);
	//alert('复制完毕');
	if(window.clipboardData)
    {
    // the IE-manier
      window.clipboardData.clearData();
      window.clipboardData.setData("Text", txt);
      alert("复制完毕");
     }
    else if(navigator.userAgent.indexOf("Opera") != -1)
    {
        window.location = txt;
        alert("链接将被转到地址栏！建议使用IE浏览器登录我们的网站：）");
    }
    else if (window.netscape)
    {
        try
        {
             netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
        } 
        catch (e) 
        {
            alert("被浏览器拒绝！\n您可以在浏览器地址栏输入'about:config'并回车\n然后将'signed.applets.codebase_principal_support'设置为'true'");
        }
        
        var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
        if (!clip){return;}

        var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
        if (!trans){return;}
  
        trans.addDataFlavor('text/unicode');
 
        var str = new Object();
        var len = new Object();
      str = Components.classes["@mozilla.org/supports-string;1"].createInstance(Components.interfaces.nsISupportsString);
      var copytext = txt;
      str.data = copytext;
      trans.setTransferData("text/unicode",str,copytext.length*2);
      var clipid = Components.interfaces.nsIClipboard;
      if (!clip){return false;}
      clip.setData(trans,null,clipid.kGlobalClipboard);
      alert("复制完毕");
 }

    
 }
 
 function CopyTextNoAlert(txt)
{
	//window.clipboardData.setData('text',text);
	//alert('复制完毕');
	if(window.clipboardData)
    {
    // the IE-manier
      window.clipboardData.clearData();
      window.clipboardData.setData("Text", txt);      
     }
    else if (window.netscape)
    {
        try
        {
             netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
        } 
        catch (e) 
        {
            alert("被浏览器拒绝！\n您可以在浏览器地址栏输入'about:config'并回车\n然后将'signed.applets.codebase_principal_support'设置为'true'");
        }
        
        var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
        if (!clip){return;}

        var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
        if (!trans){return;}
  
        trans.addDataFlavor('text/unicode');
 
        var str = new Object();
        var len = new Object();
      str = Components.classes["@mozilla.org/supports-string;1"].createInstance(Components.interfaces.nsISupportsString);
      var copytext = txt;
      str.data = copytext;
      trans.setTransferData("text/unicode",str,copytext.length*2);
      var clipid = Components.interfaces.nsIClipboard;
      if (!clip){return false;}
      clip.setData(trans,null,clipid.kGlobalClipboard);
 }

    
 }
 
 function GetCopyData(key)
 {
    //window.clipboardData.setData('text',text);
	//alert('复制完毕');
	if(window.clipboardData)
    {
    // the IE-manier
      return  window.clipboardData.getData(key);
    }
    else if (window.netscape)
    {
        try
        {
             netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
        } 
        catch (e) 
        {
            alert("被浏览器拒绝！\n您可以在浏览器地址栏输入'about:config'并回车\n然后将'signed.applets.codebase_principal_support'设置为'true'");
        }
        
        var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
        if (!clip){return;}

        var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
        if (!trans){return;}

        trans.addDataFlavor('text/unicode'); 
        clip.getData(trans,clip.kGlobalClipboard);
        var str = new Object();
        var len = new Object();
        try 
        {
            trans.getTransferData('text/unicode',str,len);
        }
        catch(error)
        {
            return null;
        }
        
        if (str)
        {
            if (Components.interfaces.nsISupportsWString)
            {
                str=str.value.QueryInterface(Components.interfaces.nsISupportsWString);
            }
            else if(Components.interfaces.nsISupportsString)
            {
                str=str.value.QueryInterface(Components.interfaces.nsISupportsString);
            }
            else str = null;
        }
        if (str)
        {
            return(str.data.substring(0,len.value / 2));
        }
    }
    return null; 
 }

function getInnerText(el) {
	if (typeof el == "string") return el;
	if (typeof el == "undefined") { return el };
	if (el.innerText) return el.innerText;	//Not needed but it is faster
	var str = "";
	
	var cs = el.childNodes;
	var l = cs.length;
	for (var i = 0; i < l; i++) {
		switch (cs[i].nodeType) {
			case 1: //ELEMENT_NODE
				str += ts_getInnerText(cs[i]);
				break;
			case 3:	//TEXT_NODE
				str += cs[i].nodeValue;
				break;
		}
	}
	return str;
}

function OverrideAddress(Url, vGn, vGa, vGs, vGt, vOt,vGk, vPv, ExecName)
	{
		Url += "-" + vGn;
		Url += "-" + "";//escape(vGh);
		Url += "-" + vGa;
		Url += "-" + vGs;
		Url += "-" + vGt;
		Url += "-" + vOt;
		Url += "-" + ((vGk == "")?"":escape(vGk));
		Url += "-" + vPv;
		Url += "." + ExecName;
		return Url;
	}
	
function OverrideAddress(Url, vGn, vGa, vGs, vGt, vOt,vGk, vPv, vAs, ExecName)
	{
		Url += "-" + vGn;
		Url += "-" + "";//escape(vGh);
		Url += "-" + vGa;
		Url += "-" + vGs;
		Url += "-" + vGt;
		Url += "-" + vOt;
		Url += "-" + ((vGk == "")?"":escape(vGk));
		Url += "-" + vPv;
		Url += "-" + vAs;
		Url += "." + ExecName;
		return Url;
	}	

var tid = null;
function blink(objId){
	
   var obj = document.getElementById(objId);
   
   if(obj != null)
   {
	   var colors=new Array();
	   colors[0]="#D52B2B"
	   colors[1]="#4D61B3"
	   colors[2]="#D52B2B" 
	   colors[3]="#4D61B3"
	   
	   var i = parseInt((colors.length-0+1) * Math.random() + 1)
	   obj.style.color = colors[i];
	   tid = setTimeout("blink('"+ objId +"')",50);
   }
}

function attach(o,e,f)
{
  if (document.attachEvent)
    o.attachEvent("on"+e,f);
  else if (document.addEventListener)
    o.addEventListener(e,f,false);
}

function request(key)
{
    var url=window.document.location.href;
    var pos=url.indexOf("?");
    var allValues=url.substr(pos + 1);

    var tmpValues = allValues.split("&");
    for(var i = 0; i < tmpValues.length; i++)
    {
        var tmpValue = tmpValues.split("=");

        if(tmpValue[0].toUpperCase()==key.toUpperCase()) 
            return tmpValue[1];
    }
    return "";
}