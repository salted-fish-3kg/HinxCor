﻿using System;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
//using HinxCor.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using HinxCor.Rendering;
using System.Text;
using LitJson;
using HinxCor.Security;
using GDIPlus;
using HinxCor.Rendering.Text;
using HinxCor.Compression.net45;
using HinxCor;
using System.Collections.Generic;
using HinxCor.Serialize;
using HinxCor.IO;
using System.Net;
using Microsoft.Win32;
using Test;
using HinxCor.WindowsForm;

namespace DemoApp
{
#pragma warning disable

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            //wget –no-check-certificate https://raw.githubusercontent.com/teddysun/shadowsocks_install/master/shadowsocks.sh
            //chmod +x shadowsocks.sh
            //./shadowsocks.sh 2>&1 | tee shadowsocks.log   

            //测试BundleFile();
            //设置路径到缓存然后新建文件打开文件夹();
            //爬网络素材资源();
            //加密自解压程序源码();
            //解密自解压程序源码();

            //测试注册表2();
            //测试文本格式化();
            //测试SQL();

            //var res = HinxCor.Win32.MessageBox.ShowTopMost("Message", "titile", HinxCor.Win32.DefaultButtons.YesNoCancel);
            //Console.WriteLine(res);
            //Console.ReadKey();

            //OpenFileDialog open = new OpenFileDialog();
            //open.ShowDialog();
            //var r = new HybridTransparentBorder(/*Image.FromFile(open.FileName)*/);
            //r.Show();
            //Console.ReadKey();
            //var Col = new PickColorDialogBase();
            //Console.WriteLine(Col.ShowAndBlock());

            //var dat =  System.Convert.FromBase64String(StringFile._SPLIT_STRING);

            //string ssr = "123456789" + StringFile._SPLIT_STRING + "abcdef";
            //var regs = Regex.Split(ssr, StringFile._SPLIT_STRING);
            //测试StringFile();
            //程序启动器资源打包();
            //测试启动界面();
            生成空白图像();
            //Console.ReadKey();
        }

        private static void 生成空白图像()
        {
            Bitmap bmp = new Bitmap(1000, 1000);
            var g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.Flush();
            g.Dispose();

            var ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);
            ms.Position = 0;
            byte[] pngdat = ms.ToArray();
            var str = System.Convert.ToBase64String(pngdat);
            Console.WriteLine(str);
            File.WriteAllText("1.txt", str);
            Console.ReadKey();
        }

        private static void 测试启动界面()
        {

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "png图像|*.png";
            open.ShowDialog();
            Image img = Image.FromFile(open.FileName);

            var loadout = new ApplicationLoadout(img);
            loadout.Show();
            loadout.CenterScreen();

            //while (Console.ReadKey().Key != ConsoleKey.Escape)
            //{
            //    loadout.SetLog(DateTime.Now);
            //}

            Console.ReadKey();
        }

        private static void 测试StringFile()
        {
            //Console.WriteLine(BitConverter.GetBytes(0).Length);

            //OpenFileDialog open = new OpenFileDialog();
            //StringFile sf = new StringFile();
            //open.Filter = "png图像|*.png";
            //for (int i = 0; i < 5; i++)
            //{
            //    open.ShowDialog();
            //    var fileName = open.FileName;
            //    sf.Add(fileName);
            //}
            ////Console.WriteLine(sf);
            //File.WriteAllText("FIR.SF", sf.ToString());

            string txt = File.ReadAllText("FIR.SF");
            var sf = new StringFile(txt);
            for (int i = 0; i < 5; i++)
            {
                var dat = sf[i];
                File.WriteAllBytes(string.Format("PNG_{0}.png", i + 1), dat);
            }
        }

        private static void 测试SQL()
        {
            //testSql.TestConnection();
        }

        private static void 测试文本格式化()
        {
            TMP_InputField inputField = new TMP_InputField()
            {
                text = "123456789",
                selectionStringAnchorPosition = 3,
                selectionStringFocusPosition = 5
            };

            DivideStringFormat.Apply("size", inputField, "5");
            DivideStringFormat.Apply("size", inputField, "5");

        }

        //#region Tag Test

        //private static void Test()
        //{
        //    string txt = "<size=12.5ffffffffffffffffffk>normal</size>";

        //    bool res = IsStringSpecialAFullTag(txt, out Tag sti);
        //    if (res) txt = RemoveSpecialTag(txt);
        //    //Console.WriteLine(res + "#" + sti.GetHeader());
        //    Console.WriteLine(txt);
        //    Console.ReadKey();
        //}

        //private static string RemoveSpecialTag(string txt)
        //{
        //    int lastIndex = txt.LastIndexOf("</");
        //    txt = txt.Remove(lastIndex, txt.Length - lastIndex);
        //    int findex = txt.IndexOf('>');
        //    txt = txt.Remove(0, findex + 1);
        //    return txt;
        //}

        //public static bool IsStringSpecialAFullTag(string v, out Tag fullTag1)
        //{
        //    string HP = @"^<[.a-zA-Z0-9=]*>";
        //    Regex Header = new Regex(HP);
        //    string FP = @"<[/a-zA-Z]*>$";
        //    Regex Footer = new Regex(FP);
        //    fullTag1 = null;

        //    if (Header.IsMatch(v) && Footer.IsMatch(v))
        //    {
        //        var hM = Tag.From(Header.Match(v).ToString());
        //        var fM = Tag.From(Footer.Match(v).ToString());
        //        if (hM.TagName.Equals(fM.TagName))
        //        {
        //            fullTag1 = hM;
        //            return true;
        //        }
        //        return false;
        //    }
        //    return false;
        //}


        //public enum TagType
        //{
        //    Head,
        //    Full,
        //    Foot
        //}

        //public class Tag
        //{
        //    public TagType Type { get; set; }

        //    public string TagName { get; set; }

        //    public object Value { get; set; }

        //    public Tag()
        //    {
        //        Type = TagType.Full;
        //        TagName = string.Empty;
        //        Value = string.Empty;
        //    }

        //    public Tag(string tgname)
        //    {
        //        Type = TagType.Full;
        //        TagName = tgname;
        //        Value = string.Empty;
        //    }
        //    public Tag(string tgname, object tgvalue)
        //    {
        //        Type = TagType.Full;
        //        TagName = tgname;
        //        Value = tgvalue;
        //    }

        //    public Tag Clone()
        //    {
        //        return new Tag()
        //        {
        //            TagName = TagName,
        //            Type = Type,
        //            Value = Value
        //        };
        //    }

        //    public string GetHeader()
        //    {
        //        return string.Format("<{0}{1}>", TagName, GetValueString(Value));
        //    }

        //    public string GetFooter()
        //    {
        //        return string.Format("</{0}>", TagName);
        //    }

        //    public static string GetValueString(object value)
        //    {
        //        //if (value == null) return string.Empty;
        //        //string str = value.ToString();
        //        //if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
        //        //    return string.Empty;
        //        //return "=" + str;

        //        return value == null ?
        //            string.Empty :
        //            (string.IsNullOrEmpty(value.ToString()) ?
        //                string.Empty :
        //                ("=" + value.ToString()));
        //    }

        //    public static Tag From(string v)
        //    {
        //        Tag tag = new Tag();

        //        if (v.Contains("="))
        //        {
        //            tag.Type = TagType.Head;
        //            int stIndex = v.IndexOf('=');
        //            var tmp = v;
        //            v = v.Remove(stIndex, v.Length - stIndex);
        //            v = v.Remove(0, 1);
        //            tag.TagName = v;
        //            tmp = tmp.Remove(0, stIndex + 1);
        //            tmp = tmp.Remove(tmp.Length - 1, 1);
        //            tag.Value = tmp;
        //            return tag;
        //        }
        //        if (v[1] == '/')
        //        {
        //            tag.Type = TagType.Foot;
        //            v = v.Remove(0, 2);
        //            v = v.Remove(v.Length - 1, 1);
        //            tag.TagName = v;
        //            return tag;
        //        }
        //        v = v.Remove(v.Length - 1, 1);
        //        tag.TagName = v.Remove(0, 1);
        //        tag.Type = TagType.Head;
        //        return tag;
        //    }


        //    public static Tag Combine(Tag head, Tag foot)
        //    {
        //        if (head.Type != TagType.Head) return null;
        //        if (foot.Type != TagType.Foot) return null;
        //        if (head.TagName.Equals(foot.TagName) == false) return null;
        //        return new Tag()
        //        {
        //            TagName = head.TagName,
        //            Type = TagType.Full,
        //            Value = head.Value
        //        };
        //    }
        //}



        //public static MatchCollection ScanTag(string v)
        //{
        //    //string tagPattern = @"<[\w]*>";
        //    string tagPattern = @"<[a-zA-Z.0-9_=/]*>";
        //    var Colle = Regex.Matches(v, tagPattern);
        //    return Colle;
        //}

        //#endregion

        private static void 测试注册表2()
        {
            int res = WindowsRegistry.RegisterDefaultApp(".fsv3", "D:\\fsv.ico", PerceivedType.vision_mod, "D:\\1\\main.exe %1", WindowsRegistry.ContentType.XComponentText);
            Console.WriteLine(res);
            Console.ReadKey();
        }

        private static void 测试注册表()
        {
            var kroot = Registry.ClassesRoot;
            var fsv = kroot.OpenSubKey(".fsv3", true);
            if (fsv != null)
                fsv.SetValue("测试键", "测试数值");
            else
            {
                fsv = kroot.CreateSubKey(".fsv3");
                fsv.SetValue("测试键_新建", "测试数值_新建");
            }
        }

        static WebClient client;

        private static void 爬网络素材资源()
        {
            //http://www.animiz.cn/client/resource/hand-painted

            // string jsonURL = @"http://www.animiz.cn/client/resource/hand-painted?search=&pagesize=30&page=1&catid=3";
            client = new WebClient();

            for (int catid = 1; catid < 30; catid++)
            {
                int page = 0;
                nextpage: page++;
                Console.WriteLine();
                Console.WriteLine("开始下载Part:" + page + ",CID: " + catid);
                string jsonRequest = string.Format(@"http://www.animiz.cn/client/resource/hand-painted?search=&pagesize=60&page={1}&catid={0}", catid, page);
                var json = client.DownloadString(jsonRequest);
                var res = LitJson.JsonMapper.ToObject<ImageList>(json);
                if (res.data.Length > 0 && page < 10)
                {
                    for (int i = 0; i < res.data.Length; i++)
                        DownLoadImageItem(res.data[i]);
                    goto nextpage;
                }
            }
            Console.WriteLine("FINIEHED");
            Console.ReadKey();
        }

        private static void DownLoadImageItem(ImageItem imageItem)
        {
            string folderName = "Download/" + imageItem.title + "/";
            if (!Directory.Exists(folderName)) Directory.CreateDirectory(folderName);
            //FileInfo f = new FileInfo(imageItem.thumbnail);
            string fname = imageItem.thumbnail.Remove(0, imageItem.thumbnail.LastIndexOf('/'));

            client.DownloadFile(imageItem.thumbnail, folderName + fname);
            Console.WriteLine("下载...: " + imageItem.thumbnail);
            client.DownloadFile(imageItem.url, folderName + fname + ".svg");
            Console.WriteLine("下载...:" + imageItem.url);
        }

        private class ImageList
        {
            public object status { get; set; }
            public accessitem[] access { get; set; }
            public ImageItem[] data { get; set; }

        }

        private class accessitem
        {
            public object access { get; set; }
            public string type { get; set; }
        }

        private class ImageItem
        {
            public string title { get; set; }
            public string url { get; set; }
            public string thumbnail { get; set; }
            public string access { get; set; }
        }





        private static void 加密自解压程序源码()
        {
            OpenFileDialog openf = new OpenFileDialog();
            openf.Filter = "CS FILE|*.cs";
            openf.ShowDialog();
            string key = "HinxCor.EncrytoPass";
            var data = File.ReadAllText(openf.FileName);
            using (var rc4 = new RC4(Encoding.UTF8.GetBytes(key)))
            {
                var encoded = rc4.Encrypt(data);
                SaveFileDialog savef = new SaveFileDialog();
                savef.Filter = "ENCRYPTED FILE|code.depub";
                savef.ShowDialog();
                File.WriteAllBytes(savef.FileName, encoded);
            }
        }

        private static void 设置路径到缓存然后新建文件打开文件夹()
        {
            string workdir = Path.GetTempPath() + "\\_self_pack_and_extracting";
            if (!Directory.Exists(workdir)) Directory.CreateDirectory(workdir);
            Environment.CurrentDirectory = workdir;

            File.Create("GG");
            FileInfo f = new FileInfo("GG");
            Windows.OpenInExplorer(f.Directory.FullName);
        }

        private static void 解密自解压程序源码()
        {
            OpenFileDialog openf = new OpenFileDialog();
            openf.ShowDialog();
            var data = File.ReadAllBytes(openf.FileName);

            string key = "HinxCor.EncrytoPass";

            using (var rc4 = new RC4(Encoding.UTF8.GetBytes(key)))
            {
                string decoded = rc4.Decrypt(data);
                SaveFileDialog savef = new SaveFileDialog();
                savef.Filter = "CS FILE|*.cs";
                savef.ShowDialog();
                File.WriteAllText(savef.FileName, decoded);
            }
        }
        private static void 程序启动器资源打包()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "配置文件|*.ini";
            openFile.ShowDialog();
            var e1 = new TxtFileEntry(openFile.FileName);
            openFile.Filter = "LoadOut|*.png";
            openFile.ShowDialog();
            var e2 = new PNGFileEntry(openFile.FileName);

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "BundleAsset|ALProfiles";
            saveFile.ShowDialog();
            FileStream fs = new FileStream(saveFile.FileName, FileMode.CreateNew);
            using (BundleFile bf = new BundleFile(fs))
            {
                bf.StartPush();
                bf.PushEntry(e1);
                bf.PushEntry(e2);
            }
            Windows.OpenInExplorer(new FileInfo(saveFile.FileName).Directory.FullName);
        }

        private static void 测试BundleFile()
        {
            //if (File.Exists("sample.txt"))
            //    File.WriteAllText("sample.txt", "sample.txt 吴亦凡 SKR SKR SKR SKR SKR SKR SKR SKR SKR SKR SKR SKR SKR SKR SKR SKR SKR SKR SKR SKR");

            //MemoryStream ms = new MemoryStream();
            //FileStream fs = new FileStream("sava.data", FileMode.CreateNew);

            FileStream fs = new FileStream("sava.data", FileMode.Open);
            BundleFile bf = new BundleFile(fs);

            //bf.PushEntry(new StringEntry("Hello,Im Hinx1"));
            //bf.PushEntry(new TxtFileEntry("sample.txt"));
            //bf.PushEntry(new PNGFileEntry("sample.png"));

            bf.StartPop();
            var outse1 = bf.PopEntry() as StringEntry;
            var outse2 = bf.PopEntry() as TxtFileEntry;
            var outse3 = bf.PopEntry() as PNGFileEntry;
            string str = outse2.GetText();
            var pic = outse3.GetImage();
            pic.Save("save31.jpg");
        }

        private static string sizeString(ulong size)
        {
            ulong kb = 1024;
            var b = size % 8;
            var k = size / 8 % kb;
            var m = size / 8 / kb % kb;
            var g = size / 8 / kb / kb % kb;
            var t = size / 8 / kb / kb / kb;
            return string.Format("{0} T {1} G {2} M {3} K {4}", t, g, m, k, b);
        }

        private static void 测试arg()
        {
            List<string> argus = new List<string>();
            argus.Add("arg1");
            argus.Add("arg2");
            argus.Add("arg3");
            argus.Add("arg4");
            argus.Add("arg5");
            argus.Add("arg6");

            string resd = Arguments.PackArguments(argus);
            Console.WriteLine(resd);
        }

        private static void 异步单线测试打包文件夹()
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.RootFolder = Environment.SpecialFolder.MyComputer;
            f.ShowDialog();
            var dir = f.SelectedPath;
            var files = GetFilesAndDirs(new DirectoryInfo(dir));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var ao = new AsyncOperator();
            var ap = new AsyncOperate(ao);
            ap.Start();
            Action<string> log = str =>
            {
                ao.log = str;
                //Console.SetCursorPosition(0, 1);
                //Console.WriteLine(str);
            };
            Action<float> p = str =>
            {
                ao.process = str;
                //Console.SetCursorPosition(0, 0);
                //Console.WriteLine((str * 100).ToString("F") + "%");
            };
            bool finished = false;
            Action<bool> state = b =>
            {
                ao.isdone = b;
                finished = b;
            };
            Action<Exception> handle = e =>
            {
                Console.SetCursorPosition(0, 3);
                Console.WriteLine(e.ToString());
            };

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "zip文件|*.zip";
            save.ShowDialog();
            var r = new Thread(() =>
            {
                ZipHelper.ASyncCompressFilesAndFolder(p, log, state, handle, files, save.FileName, 9, "", "测试创建的zip文件,密码为123");
            })
            {
                IsBackground = true
            };

            r.Start();

            while (ap.isDone == false)
            {
                Console.Clear();
                Console.WriteLine(ap.isDone);
                Console.WriteLine((ap.progress * 100).ToString("F") + "%");
                Console.WriteLine(ap.Log);
                Thread.Sleep(50);
            }
            Console.Clear();
            Console.WriteLine(ap.isDone);
            Console.WriteLine((ap.progress * 100).ToString("F") + "%");
            Console.WriteLine(ap.Log);

            Console.SetCursorPosition(0, 4);
            Console.WriteLine("FINISHED");
            Console.ReadKey();

        }

        public static string[] GetFilesAndDirs(DirectoryInfo dir)
        {
            List<string> cols = new List<string>();
            cols.AddRange(Directory.GetFiles(dir.FullName));
            cols.AddRange(Directory.GetDirectories(dir.FullName));
            return cols.ToArray();
        }

        /// <summary>
        /// 测试
        /// </summary>
        private static void TestAsync()
        {
            var ao = new AsyncOperator();
            AsyncOperate aop = new AsyncOperate(ao);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            aop.Start();
            var THR = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    //ao.process = i / 100f;
                    Thread.Sleep(1000);
                }
            })
            {
                IsBackground = true
            };
            THR.Start();
            while (!aop.isDone)
            {
                //Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.Write((aop.progress * 100).ToString("F") + "%");
                Thread.Sleep(10);
            }

            Console.SetCursorPosition(0, 5);
            //Console.WriteLine("Start..");
            Console.ReadKey();
        }

        private static void 测试苹果()
        {
            Fruit f = new Fruit()
            {
                alpe = new Apple()
                {
                    weight = 998
                }
            };

            basket bsk = new basket();
            bsk.Apple = f.alpe;
            var ap = bsk.Apple;
            ap.weight = 55;
        }

        private class basket
        {
            public Apple Apple { get; set; }
        }

        private class Fruit
        {
            public string Name { get; set; }
            public Apple alpe { get; set; }
        }

        [Serializable]
        private class Apple
        {
            public float weight { get; set; }
        }

        private class fakeColor
        {
            public float a;
            public float b;
            public float c;
        }

        private abstract class parent
        {
            public parent(string sname)
            {
                Console.WriteLine("parent:" + sname);
            }
        }

        private class child : parent
        {
            public child(string sname) : base(sname)
            {
                Console.WriteLine("Child.");
            }
        }


        private static void Print<T>(T go)
        {
            // int all false

            Console.WriteLine(go);
            Console.WriteLine("@i+nt:" + go is int);
            Console.WriteLine("@u+int:" + go is uint);
            Console.WriteLine("@s+hort:" + go is short);
            Console.WriteLine("@u+short:" + go is ushort);
            Console.WriteLine("@l+ong:" + go is long);
            Console.WriteLine("@u+long:" + go is ulong);
            Console.WriteLine("@c+har:" + go is char);
            Console.WriteLine("@s+ingle:" + go is float);
            Console.WriteLine("@d+ouble:" + go is double);
            Console.WriteLine("@b+ool:" + go is bool);
            //Console.WriteLine();
        }

        private static void 测试For循环()
        {
            long a = 0;

            //return -3;
            //Console.ReadKey();
            for (int l = 0; l < 10; l++)
            {
                //Console.Clear();

                var t1 = DateTime.Now;
                int p = 100000;
                int q = 4000;
                for (int i = 0; i < p; i++)
                    for (int j = 0; j < q; j++)
                        a++;

                var ms = (DateTime.Now - t1).TotalMilliseconds;
                Console.WriteLine(string.Format("{1} Use {0} ms, {2} Ghz ", ms, q * p, (p * q * 0.001f * 0.001f / ms).ToString("F")));

            }
            Console.WriteLine(a);
            Console.ReadKey();
        }

        private static void 测试加密文件()
        {

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "脚本|SELFEXTRACTING.cs";
            open.ShowDialog();
            var data = File.ReadAllText(open.FileName);
            string key = "HinxCor.EncrytoPass";

            string saveName = "";
            using (var coder = new RC4(Encoding.UTF8.GetBytes(key)))
            {
                var buff = coder.Encrypt(data);
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "密文|code.depub";
                save.ShowDialog();
                saveName = save.FileName;
                File.WriteAllBytes(save.FileName, buff);
            }
            Thread.Sleep(100);
            Console.WriteLine("加密完成. 尝试解密");
            var encryptData = File.ReadAllBytes(saveName);
            using (var coder = new RC4(Encoding.UTF8.GetBytes(key)))
            {
                var csdetail = coder.Decrypt(encryptData);
                Console.WriteLine(csdetail);
            }

            Console.WriteLine();
            Console.WriteLine("################finished#######################");
            Console.ReadKey();

        }

        private static void ChechDir(DirectoryInfo dir)
        {
            if (dir.Exists) return;
            ChechDir(dir.Parent);
            dir.Create();
        }


        static void 测试加密RC4()
        {
            string key = "HinxCor.EncrytoPass";
            string codePass = "你好,世界. From HinxCor.Cryto";
            byte[] array = Encoding.UTF8.GetBytes(key);
            byte[] message = Encoding.UTF8.GetBytes(codePass);
            using (RC4 rC4 = new RC4(array))
            {
                Console.WriteLine("原文:" + codePass);
                var cd = rC4.encrypt(message);
                Console.WriteLine("密文:" + Encoding.UTF8.GetString(cd));
                var dr = rC4.Decrypt((RC4.ByteArray)cd);
                Console.WriteLine("明文:" + Encoding.UTF8.GetString(dr));
                Console.ReadKey();
            }

        }

        static void clcintarray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }


        private void fff()
        {
            ImporterFunc<string, Single> importer = delegate (string fl)
            {
                return Single.Parse(fl);
            };
            ExporterFunc<Single> exporter = delegate (Single num, JsonWriter writer)
            {
                writer.Write(num.ToString());
            };

            ImporterFunc<string, Color> importerc = delegate (string fl)
            {
                Console.WriteLine("from Pareset:" + fl);
                return Color.White;
            };
            ExporterFunc<Color> exporterc = delegate (Color num, JsonWriter writer)
            {
                writer.WriteArrayStart();
                writer.WriteObjectStart();
                writer.WritePropertyName("A");
                writer.Write(num.A);
                writer.WritePropertyName("R");
                writer.Write(num.R);
                writer.WritePropertyName("G");
                writer.Write(num.G);
                writer.WritePropertyName("B");
                writer.Write(num.B);
                writer.WriteObjectEnd();
                writer.WriteArrayEnd();
            };

            JsonMapper.RegisterExporter(exporter);
            JsonMapper.RegisterImporter(importer);
            JsonMapper.RegisterExporter(exporterc);
            JsonMapper.RegisterImporter(importerc);


            txtobj obj = new txtobj();
            string json = LitJson.JsonMapper.ToJson(obj);
            var go = JsonMapper.ToObject<txtobj>(json);

            JsonMapper.UnregisterExporters();
            JsonMapper.UnregisterImporters();
            Console.WriteLine(json);
            Console.ReadKey();
        }

        [System.Serializable]
        public class txtobj
        {
            public TextRenderingHint renderingHint;
            //public Rectangle rect;
            public float LineSpacing;
            public int CharSpacing;
            //public System.Drawing.Color bgColor;
            public StringFormat stringFormat;
            public string FontName;
            public int FontSize;
            public System.Drawing.Color fontColor;
            public string Text;
            public System.Drawing.FontStyle fontStyle;
            public bool verticalF;
        }


        /// <summary>
        /// 测试两种不同的绘制方法的耗时量
        /// A 计算 DrawText 可以设置行距和字距, B 计算是常规计算
        /// 绘制结果相同;比较时差
        /// </summary>
        private static void DemoFun计算高次绘制Bitmap耗时()
        {
            Console.WriteLine("开始测试");
            string str =
    @"---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
---------------------------------------------------------
";

            Font font = new Font("微软雅黑", 48);
            StringFormat ffffff = StringFormat.GenericDefault;
            int testcount = 2;
            DateTime t;
            double ta = 0, tb = 0, tc = 0, td = 0;
            int c2 = 20;
            Console.WriteLine("[                    ] 000%");//18 14
            for (int j = 0; j < c2; j++)
            {
                t = System.DateTime.Now;
                for (int i = 0; i < testcount; i++)
                    BitmapGenerator.DrawText(str, font, Rectangle.Empty, ffffff, 5, 5, new SolidBrush(Color.Gray), Color.Transparent, System.Drawing.Text.TextRenderingHint.AntiAlias);
                ta += (System.DateTime.Now - t).TotalMilliseconds;
                t = System.DateTime.Now;
                for (int i = 0; i < testcount; i++)
                    BitmapGenerator.GetBitmap(str, font, Rectangle.Empty, Color.Gray, Color.Transparent, ffffff, System.Drawing.Text.TextRenderingHint.AntiAlias);
                tb += (System.DateTime.Now - t).TotalMilliseconds;
                GC.Collect();
                Console.SetCursorPosition(j + 1, 1);
                Console.Write("#");
                Console.SetCursorPosition(23, 1);
                Console.Write((j >= 0 && j < c2 - 1 ? "-" : "") + (j < 1 ? "0" : "") + (j + 1) * 100 / c2 + "%");
            }
            Console.WriteLine();
            Console.WriteLine("测试结束,测试次数:" + testcount * c2);
            Console.WriteLine(string.Format("A测试(遍历)总共耗时:{0},平均耗时:{1} ms", ta.ToString("F"), (ta / c2 / testcount).ToString("F")));
            Console.WriteLine(string.Format("B测试(顺序)总共耗时:{0},平均耗时:{1} ms", tb.ToString("F"), (tb / c2 / testcount).ToString("F")));
            var timespy = ta - tb;
            Console.WriteLine(string.Format("测试总共时差:{0},平均时差:{1} ms", timespy.ToString("F"), (timespy / c2 / testcount).ToString("F")));
            var bmp = BitmapGenerator.DrawText(str, font, Rectangle.Empty, ffffff, 0, 0, new SolidBrush(Color.Gray), Color.Transparent, System.Drawing.Text.TextRenderingHint.AntiAlias);
            Console.WriteLine(string.Format("A绘制尺寸{0}x{1},共计{2} pix", bmp.Width, bmp.Height, bmp.Width * bmp.Height));
            bmp = BitmapGenerator.GetBitmap(str, font, Rectangle.Empty, Color.Gray, Color.Transparent, ffffff, System.Drawing.Text.TextRenderingHint.AntiAlias);
            Console.WriteLine(string.Format("B绘制尺寸{0}x{1},共计{2} pix", bmp.Width, bmp.Height, bmp.Width * bmp.Height));


            testcount = 1;
            Console.WriteLine("[                    ] 000%");//24 14
            for (int j = 0; j < c2; j++)
            {

                t = System.DateTime.Now;
                FastBitmap fbmp = new FastBitmap(bmp);
                fbmp.Lock();
                for (int i = 0; i < testcount; i++)
                    for (int w = 0; w < bmp.Width; w++)
                        for (int h = 0; h < bmp.Height; h++)
                        {
                            var c = fbmp.GetPixel(1, 1);//t = 1???
                            fbmp.SetPixel(w, h, c);
                        }
                fbmp.Unlock();
                tc += (System.DateTime.Now - t).TotalMilliseconds;
                TextObject obj = new TextObject();
                t = System.DateTime.Now;
                for (int i = 0; i < testcount; i++)
                {
                    var size = obj.Size;
                }
                //for (int w = 0; w < bmp.Width; w++)
                //    for (int h = 0; h < bmp.Height; h++)
                //    {
                //        int index = 0;
                //        //bmp.SetPixel(w, h, bmp.GetPixel(w, h));
                //    }
                td += (System.DateTime.Now - t).TotalMilliseconds;
                GC.Collect();

                Console.SetCursorPosition(j + 1, 8);
                Console.Write("#");
                Console.SetCursorPosition(23, 8);
                Console.Write((j >= 0 && j < c2 - 1 ? "-" : "") + (j < 1 ? "0" : "") + (j + 1) * 100 / c2 + "%");

            }

            Console.WriteLine();
            Console.WriteLine("像素克隆测试结束,测试次数:" + testcount * c2);
            Console.WriteLine(string.Format("FastBitmap总共耗时:{0},平均耗时:{1} ms", ta.ToString("F"), (tc / c2 / testcount).ToString("F")));
            Console.WriteLine(string.Format("getSize耗时:{0},平均耗时:{1} ms", tb.ToString("F"), (td / c2 / testcount).ToString("F")));
            timespy = td - tc;
            Console.WriteLine(string.Format("测试总共时差:{0},平均时差:{1} ms", timespy.ToString("F"), (timespy / c2 / testcount).ToString("F")));
            Console.WriteLine(string.Format("FBMP尺寸{0}x{1},共计{2} pix", bmp.Width, bmp.Height, bmp.Width * bmp.Height));
            //bmp = BitmapGenerator.GetBitmap(str, font, Rectangle.Empty, Color.Gray, Color.Transparent, ffffff, System.Drawing.Text.TextRenderingHint.AntiAlias);
            //Console.WriteLine(string.Format("BMP尺寸{0}x{1},共计{2} pix", bmp.Width, bmp.Height, bmp.Width * bmp.Height));


            Console.ReadKey();

        }


        /// <summary>
        /// 测试写入bitmap
        /// </summary>
        private static void DemoFunc4d65af4864f867()
        {
            Form2 test = new Form2();
            test.ShowDialog();

        }

        private static void DemoFunc84as6f4as354f()
        {
            //Font font = GetFont();
            //Console.WriteLine(font.GdiCharSet);
            //Console.ReadKey();

            var pth = GetPath();
            Console.WriteLine(new FileInfo(pth).Extension);
            Console.ReadKey();
        }

        /// <summary>
        /// 测试默认字体微软雅黑的属性
        /// </summary>
        private static void DemoMethodf4a65f153e()
        {
            Font f = GetFont();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("FontName:{0}", f.Name));
            sb.AppendLine(string.Format("OriginFN:{0}", f.OriginalFontName));
            sb.AppendLine(string.Format("SystemFN:{0}", f.SystemFontName));
            sb.AppendLine(string.Format("FFamilyN:{0}", f.FontFamily.Name));

            StringFormat format = new StringFormat();
            int a = 2;
            Bitmap bitmap;
            if (a == 1)
                bitmap = BitmapGenerator.GetBitmap(sb.ToString(), f, default(Rectangle), Color.Gray, Color.Transparent, StringFormat.GenericDefault, TextRenderingHint.AntiAlias);
            else bitmap = BitmapGenerator.DrawString(sb.ToString(), f, default(Rectangle), 5, 3, Color.Gray, Color.Transparent, format, TextRenderingHint.AntiAlias);
            //string pth = GetPath();
            string folder = /*GetFolder();*/ "D:\\Demo Output";
            bitmap.Save(folder + "/" + f.Name + a + "_" + f.Size + ".png", ImageFormat.Png);
            OpenInExplorer(folder);

        }

        /// <summary>
        /// 测试字符绘制的长度
        /// </summary>
        private static void DemoTestCharLength()
        {
            Bitmap bitmap = new Bitmap(1, 1);
            Font f = GetFont();
            Graphics g = Graphics.FromImage(bitmap);
            float a11 = g.MeasureString(" ", f).Width;
            float a21 = g.MeasureString("  ", f).Width;
            float a31 = g.MeasureString("   ", f).Width;
            float a41 = g.MeasureString("    ", f).Width;
            float b1 = g.MeasureString("x", f).Width;
            float b2 = g.MeasureString("xx", f).Width;
            float b3 = g.MeasureString("xxx", f).Width;
            float b4 = g.MeasureString("xxxx", f).Width;
            float a2 = g.MeasureString("\r", f).Width;
            float a3 = g.MeasureString("\n", f).Width;
            float a4 = g.MeasureString("\t", f).Width;
            float a5 = g.MeasureString("\n\r", f).Width;
            string str = System.Environment.NewLine;
            Console.ReadKey();
        }

        /// <summary>
        /// 测试段落生成工具
        /// </summary>
        private static void DemoMethod2d5f8a()
        {
            string str = "你好,中国" + "\n" +
                "这是新的内容哦,卡卡卡卡卡卡卡卡" + "\n" +
                "hello world" + "\n" +
                "GG bold&#03;" +
                "狗狗狗" + "\n" +
                "1234567890" + "\r\n"
                + "H啊哈哈哈";


            Console.WriteLine("请输入段落文本,输入Q + Enter 结束");
            //string str = "";
            //string enline;
            //while (!(enline = Console.ReadLine()).Equals("Q"))
            //{
            //    str += enline + "\n";
            //}
            Console.WriteLine("输入完成. 开始写入(1000次)");
            var font = GetFont();
            StringFormat format = new StringFormat();

            Func<string, Bitmap> drawStr = mstr =>
             {
                 return BitmapGenerator.DrawString(str, font, default(Rectangle), 25, 20, Color.Gray, Color.White, format, TextRenderingHint.AntiAlias);
             };
            Func<string, Bitmap> getBmp = mstr =>
           {
               return BitmapGenerator.GetBitmap(str, font, default(Rectangle), Color.Gray, Color.White, format, TextRenderingHint.AntiAlias);
           };

            var t = System.DateTime.Now;
            for (int i = 0; i < 1000; i++)
                drawStr(str);
            Console.WriteLine(string.Format("耗时:{0} ms,写入完成. ", (System.DateTime.Now - t).TotalMilliseconds));

            t = System.DateTime.Now;
            for (int i = 0; i < 1000; i++)
                getBmp(str);
            Console.WriteLine(string.Format("耗时:{0} ms,写入完成. ", (System.DateTime.Now - t).TotalMilliseconds));

            var bmp = drawStr(str);
            string pth = GetPath();
            bmp.Save(pth, ImageFormat.Png);
            int p = pth.LastIndexOf('.');
            pth = pth.Insert(p - 1, " 1");
            bmp = getBmp(str);
            bmp.Save(pth, ImageFormat.Png);
            OpenFileInExplorer(pth);
            Console.WriteLine("OK");
            //Console.ReadKey();
        }


        /// <summary>
        /// 测试不同情况下渲染结果的优劣
        /// </summary>
        private static void DemoMethodsd453()
        {
            var font = GetFont();
            string folder = /*GetFolder()*/"D:\\Demo Output";

            Rectangle rect = new Rectangle();
            int lh = (int)(font.Size + font.Height);
            Bitmap bmp = new Bitmap(550, lh * 6);
            Graphics.FromImage(bmp).Clear(bgColor);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                var hint = (TextRenderingHint)i;
                sb.AppendLine("中文支持" + hint);
                //rect.Y = i * lh;
                //bmp = GetBitmap(bmp, font, rect, hint);
            }
            //rect.Y = 6 * lh;
            //bmp = GetBitmap(bmp, "中文支持", font, rect, fontColor, bgColor, format, TextRenderingHint.AntiAlias);
            //var pth = GetPath();
            var pth = folder + "/" + font.Name + "_property.png";
            bmp.Save(pth, ImageFormat.Png);
            OpenFileInExplorer(pth);

            // ShowInExplorer(pth);
        }

        private static Color fontColor = Color.Gray;
        private static Color bgColor = Color.White;
        private static StringFormat format = new StringFormat();

        private static Bitmap GetBitmap(Bitmap bmp, Font font, Rectangle rect, TextRenderingHint renderinghint)
        {
            string text = "中文支持:" + renderinghint.ToString();
            //return BitmapGenerator.DrawString(bmp, text, font, rect, renderinghint);
            return GetBitmap(bmp, text, font, rect, fontColor, bgColor, format, renderinghint);
        }

        private static Bitmap GetBitmap(Bitmap bmp, string text, Font font, Rectangle rect, Color fontColor, Color backColor, StringFormat format, TextRenderingHint renderingHint)
        {
            //Bitmap bmp = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(bmp);
            var size = g.MeasureString(text, font);

            //设置背景
            //g.Clear(backColor);

            // 蚂蚁线填充边框
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // The interpolation mode determines how intermediate values between two endpoints are calculated.
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Use this property to specify either higher quality, slower rendering, or lower quality, faster rendering of the contents of this Graphics object.
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            // This one is important
            g.TextRenderingHint = renderingHint;

            g.DrawString(text, font, new SolidBrush(fontColor), rect, format);

            g.Flush();
            return bmp;
        }


        private static string GetFolder()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.RootFolder = Environment.SpecialFolder.MyComputer;
            while (folder.ShowDialog() != DialogResult.OK) ;
            return folder.SelectedPath;
        }

        /// <summary>
        /// 测试遍历写入和 一次性绘制的时间差异
        /// </summary>
        private static void DemoMethod564a6c()
        {
            Bitmap bmp = new Bitmap(1, 1);
            string str = "hello world,this is an test program.\n 这是一个测试用的程序,你好,世界.";
            var strArray = str.ToCharArray();
            Graphics g = Graphics.FromImage(bmp);
            Font f = GetFont();

            var size = g.MeasureString(str, f);
            bmp = new Bitmap(bmp, (int)size.Width, (int)size.Height);
            Brush b = new SolidBrush(Color.Black);

            int cercleCount = 2000;
            int timemul = 1;
            double[] ta = new double[50];
            double[] tb = new double[50];
            var t = System.DateTime.Now;
            for (int i = 0; i < 50; i++)
            {
                for (int o = 0; o < cercleCount; o++)
                {
                    g.DrawString(str, f, b, 0, 0);
                    g.Flush();
                }
                ta[i] = (System.DateTime.Now - t).TotalMilliseconds * timemul;
                //Console.WriteLine("A" + i + " 用时:" + (ta).ToString("F3"));
                t = System.DateTime.Now;
                for (int o = 0; o < cercleCount; o++)
                {
                    int num = strArray.Length;
                    int currentpx = 0;
                    int currentpy = 0;
                    for (int j = 0; j < num; j++)
                    {
                        var ss = g.MeasureString(strArray[i].ToString(), f);
                        g.DrawString(strArray[i].ToString(), f, b, currentpx, currentpy);
                        currentpx += (int)ss.Width;
                        currentpy += (int)ss.Height;
                    }
                    g.Flush();
                }
                tb[i] = (System.DateTime.Now - t).TotalMilliseconds * timemul;
                //Console.WriteLine("B" + i + " 用时:" + (tb).ToString("F3"));
                //Console.WriteLine(string.Format("时间差: {0} ms", tb - ta));
                //Console.WriteLine();
                //Console.WriteLine();
                Console.Write("*");
                t = System.DateTime.Now;
            }
            Console.WriteLine();
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(string.Format("A{0}:{1}, \tB{0}:{2}, \t时间差:{3} ms", i, ta[i], tb[i], tb[i] - ta[i]));
                Console.WriteLine();
            }

            Console.ReadKey();
        }


        private static Font GetFont()
        {
            FontDialog f = new FontDialog();
            f.ShowEffects = true;
            f.ShowColor = true;
            f.ShowApply = true;
            f.ShowDialog();
            return f.Font;
        }

        public static void DemoFontTxt()
        {

            FontDialog f = new FontDialog();
            f.ShowDialog();
            Font font = f.Font;
            //FontFamily family = new FontFamily("");
            //StringFormat format;

            Console.WriteLine("writeImage");
            var str = Console.ReadLine();
            var bmp = new Bitmap(1, 1);
            //var bmp = Helper.CreateBitmapImage(str, font);
            var save = new SaveFileDialog();
            save.Filter = ".png|*.png";
            if (save.ShowDialog() == DialogResult.OK)
            {
                string ph = save.FileName;
                bmp.Save(ph, ImageFormat.Png);
                Console.WriteLine("OK");
                //ShowInExplorer(ph);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Abort.");
                Console.ReadKey();
            }

        }

        public static void DemoColorPicker()
        {
            //OpenFileDialog open = new OpenFileDialog();
            //while (open.ShowDialog() != DialogResult.OK) ;
            //var fname = open.FileName;
            //HinxCor.Drawing.ColorPickerDisplayer pp = new HinxCor.Drawing.ColorPickerDisplayer();
            //pp.ShowPicker(fname);
            //Console.WriteLine(pp.color);
            //Console.ReadKey();
        }

        public static void DemoMethodTestMousePos()
        {
            int t = 5;
            while (t-- > 0)
            {
                Point p;
                de.GetCursorPos(out p);
                Console.WriteLine(p.X + "#" + p.Y);
                Thread.Sleep(500);
            }
            Console.ReadKey();
        }

        private static void DemoMethod546ad2()
        {
            ScreenCapture sc = new ScreenCapture();
            Image img = sc.CaptureScreen();
            SaveFileDialog sav = new SaveFileDialog();
            sav.Filter = "png(图片)|*.png";
            if (sav.ShowDialog() == DialogResult.OK)
                img.Save(sav.FileName);


            // capture entire screen, and save it to a file
            // display image in a Picture control named imageDisplay
            ////this.imageDisplay.Image = img;
            //this.pictureBox1.Image = img;
            //// capture this window, and save it
            //sc.CaptureWindowToFile(this.Handle, "C:\\temp2.jpg", ImageFormat.Jpeg);
        }

        private static string GetPath(string filter = "png图片|*.png")
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Filter = filter;
            while (sav.ShowDialog() != DialogResult.OK)
                sav.Title = "直到你选择保存位置为止";
            return sav.FileName;
        }

        /// <summary>
        /// 测试
        /// </summary>
        private static void DemoMethod5d3f()
        {
            Console.WriteLine("writeImage");
            var str = Console.ReadLine();
            var bmp = new Bitmap(1, 1);
            //var bmp = Helper.CreateBitmapImage(str);
            var save = new SaveFileDialog();
            save.Filter = ".png|*.png";
            if (save.ShowDialog() == DialogResult.OK)
            {
                string ph = save.FileName;
                bmp.Save(ph, ImageFormat.Png);
                Console.WriteLine("OK");
                //ShowInExplorer(ph);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Abort.");
                Console.ReadKey();
            }
        }


        [Obsolete]
        private static void ShowInExplorer(string fileName)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select," + fileName);
        }

        /// <summary>
        /// 在Windows资源管理器上打开该文件夹
        /// </summary>
        /// <param name="path"></param>
        public static void OpenInExplorer(string path)
        {
            path = path.Replace('/', '\\');
            System.Diagnostics.Process.Start("explorer.exe", path);
        }

        public static void OpenFileInExplorer(string fileName)
        {
            OpenInExplorer(new FileInfo(fileName).Directory.FullName);
        }

        private static void DemoApp23ef()
        {
            Console.WriteLine("This is an console demo app, any key to exit.");
            Console.ReadKey();
        }

        [Obsolete]
        private static void DemoTxt()
        {
            string infoString = "";  // enough space for one line of output
            int ascent;             // font family ascent in design units
            float ascentPixel;      // ascent converted to pixels
            int descent;            // font family descent in design units
            float descentPixel;     // descent converted to pixels
            int lineSpacing;        // font family line spacing in design units
            float lineSpacingPixel; // line spacing converted to pixels

            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(
               fontFamily,
               16, FontStyle.Regular,
               GraphicsUnit.Pixel);
            PointF pointF = new PointF(10, 10);
            SolidBrush solidBrush = new SolidBrush(Color.Black);

            // Display the font size in pixels.
            infoString = "font.Size returns " + font.Size + ".";
            //e.Graphics.DrawString(infoString, font, solidBrush, pointF);

            // Move down one line.
            pointF.Y += font.Height;

            // Display the font family em height in design units.
            infoString = "fontFamily.GetEmHeight() returns " +
               fontFamily.GetEmHeight(FontStyle.Regular) + ".";
            //e.Graphics.DrawString(infoString, font, solidBrush, pointF);

            // Move down two lines.
            pointF.Y += 2 * font.Height;

            // Display the ascent in design units and pixels.
            ascent = fontFamily.GetCellAscent(FontStyle.Regular);

            // 14.484375 = 16.0 * 1854 / 2048
            ascentPixel =
               font.Size * ascent / fontFamily.GetEmHeight(FontStyle.Regular);
            infoString = "The ascent is " + ascent + " design units, " + ascentPixel +
               " pixels.";
            //e.Graphics.DrawString(infoString, font, solidBrush, pointF);

            // Move down one line.
            pointF.Y += font.Height;

            // Display the descent in design units and pixels.
            descent = fontFamily.GetCellDescent(FontStyle.Regular);

            // 3.390625 = 16.0 * 434 / 2048
            descentPixel =
               font.Size * descent / fontFamily.GetEmHeight(FontStyle.Regular);
            infoString = "The descent is " + descent + " design units, " +
               descentPixel + " pixels.";
            //e.Graphics.DrawString(infoString, font, solidBrush, pointF);

            // Move down one line.
            pointF.Y += font.Height;

            // Display the line spacing in design units and pixels.
            lineSpacing = fontFamily.GetLineSpacing(FontStyle.Regular);

            // 18.398438 = 16.0 * 2355 / 2048
            lineSpacingPixel =
            font.Size * lineSpacing / fontFamily.GetEmHeight(FontStyle.Regular);
            infoString = "The line spacing is " + lineSpacing + " design units, " +
               lineSpacingPixel + " pixels.";
            // e.Graphics.DrawString(infoString, font, solidBrush, pointF);
        }

    }
}


class de
{

    //using System.Runtime.InteropServices;
    Point p;
    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out Point pt);
    private void timer1_Tick(object sender, EventArgs e)
    {
        GetCursorPos(out p);
        //label1.Text = p.X.ToString();//X坐标
        //label2.Text = p.Y.ToString();//Y坐标
    }
}
