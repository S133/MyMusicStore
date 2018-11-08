using CodeFirst1108.DataContext;
using CodeFirst1108.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using MoreLinq;

namespace CodeFirst1108.Migrations
{
    public class StudentSeed
    {
        public static void Seed(StuDBContext context)
        {
            var d1 = context.DepartMents.SingleOrDefault(x => x.Name == "电子信息工程学院");
            for (var i = 0; i < 400; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);
                var student = new Student()
                {
                    StudentNo = "DZXX" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "社湾路28号",
                    Department = d1,
                    Phone = "18346485269"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            var d2 = context.DepartMents.SingleOrDefault(x => x.Name == "机电工程学院");
            for (var i = 0; i < 300; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);
                var student = new Student()
                {
                    StudentNo = "JDGC" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "社湾路28号",
                    Department = d2,
                    Phone = "18346485269"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            var d3 = context.DepartMents.SingleOrDefault(x => x.Name == "汽车工程学院");
            for (var i = 0; i < 200; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);
                var student = new Student()
                {
                    StudentNo = "QCGC" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "社湾路28号",
                    Department = d3,
                    Phone = "18346485879"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            var d4 = context.DepartMents.SingleOrDefault(x => x.Name == "贸易与旅游学院");
            for (var i = 0; i < 150; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);
                var student = new Student()
                {
                    StudentNo = "MYYLY" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "社湾路28号",
                    Department = d4,
                    Phone = "18381485269"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            var d5 = context.DepartMents.SingleOrDefault(x => x.Name == "财经与物流学院");
            for (var i = 0; i < 100; i++)
            {
                var fname = "";
                var lname = "";
                var fullname = _GetRandomChineseFullName(ref fname, ref lname);
                var student = new Student()
                {
                    StudentNo = "CJYWL" + i.ToString("0000"),
                    FirstName = fname,
                    LastName = lname,
                    FullName = fullname,
                    BirthDay = DateTime.Now,
                    Address = "社湾路28号",
                    Department = d5,
                    Phone = "18746485269"
                };
                context.Students.Add(student);
                Thread.Sleep(1);
            }
            context.SaveChanges();
            _GarbageClear();
        }
       
        public static string _GetRandomChineseFullName(ref string firstName,ref string lasrName)
        {
            string[] _seedFirstName = new string[]
            {
                "赵","钱","孙","李","周","吴","郑","王","冯","陈","褚","卫",
                "蒋","沈","韩","杨","朱","秦","尤","许","何","吕","施","张",
                "孔","曹","严","华","金","魏","陶","姜","戚","谢","邹","喻",
                "柏","水","窦","章","云","苏","潘","葛","奚","范","彭","郎",
                "鲁","韦","昌","马","苗","凤","花","方","俞","任","袁","柳",
                "酆","鲍","史","唐","费","廉","岑","薛","雷","贺","倪","汤",
                "滕","殷","罗","毕","郝","邬","安","常","乐","于","时","傅",
                "皮","卞","齐","康","伍","余","元","卜","顾","孟","平","黄",
                "和","穆","萧","尹","姚","邵","湛","汪","祁","毛","禹","狄",
                "米","贝","明","臧","计","伏","成","戴","谈","宋","茅","庞",
                "熊","纪","舒","屈","项","祝","董","梁","杜","阮","蓝","闵",
                "席","季","麻","强","贾","路","娄","危","江","童","颜","郭",
                "梅","盛","林","刁","钟","徐","邱","骆","高","夏","蔡","田",
                "樊","胡","凌","霍","虞","万","支","柯","昝","管","卢","莫",
                "经","房","裘","缪","干","解","应","宗","丁","宣","贲","邓",
                "郁","单","杭","洪","包","诸","左","石","崔","吉","钮","龚",
                "程","嵇","邢","滑","裴","陆","荣","翁","荀","羊","於","惠",
                "甄","曲","家","封","芮","羿","储","靳","汲","邴","糜","松",
                "井","段","富","巫","乌","焦","巴","弓","牧","隗","山","谷",
                "车","侯","宓","蓬","全","郗","班","仰","秋","仲","伊","宫",
                "宁","仇","栾","暴","甘","钭","厉","戎","祖","武","符","刘",
                "景","詹","束","龙","叶","幸","司","韶","郜","黎","蓟","薄",
                "印","宿","白","怀","蒲","邰","从","鄂","索","咸","籍","赖",
                "卓","蔺","屠","蒙","池","乔","阴","鬱","胥","能","苍","双",
                "闻","莘","党","翟","谭","贡","劳","逄","姬","申","扶","堵",
                "冉","宰","郦","雍","卻","璩","桑","桂","濮","牛","寿","通",
                "边","扈","燕","冀","郏","浦","尚","农","温","别","庄","晏",
                "柴","瞿","阎","充","慕","连","茹","习","宦","艾","鱼","容",
                "向","古","易","慎","戈","廖","庾","终","暨","居","衡","步",
                "都","耿","满","弘","匡","国","文","寇","广","禄","阙","东",
                "欧","殳","沃","利","蔚","越","夔","隆","师","巩","厍","聂",
                "晁","勾","敖","融","冷","訾","辛","阚","那","简","饶","空",
                "曾","毋","沙","乜","养","鞠","须","丰","巢","关","蒯","相",
                "查","后","荆","红","游","竺","权","逯","盖","益","桓","公",
                "万","俟","司","马","上","官","欧","阳","夏","侯","诸","葛",
                "闻","人","东","方","赫","连","皇","甫","尉","迟","公","羊",
                "澹","台","公","冶","宗","政","濮","阳","淳","于","单","于",
                "太","叔","申","屠","公","孙","仲","孙","轩","辕","令","狐",
                "钟","离","宇","文","长","孙","慕","容","鲜","于","闾","丘",
                "司","徒","司","空","丌","官","司","寇","仉","督","子","车",
                "颛","孙","端","木","巫","马","公","西","漆","雕","乐","正",
                "壤","驷","公","良","拓","跋","夹","谷","宰","父","谷","梁",
                "晋","楚","闫","法","汝","鄢","涂","钦","段","干","百","里",
                "东","郭","南","门","呼","延","归","海","羊","舌","微","生",
                "岳","帅","缑","亢","况","郈","有","琴","梁","丘","左","丘",
                "东","门","西","门","商","牟","佘","佴","伯","赏","南","宫",
                "墨","哈","谯","笪","年","爱","阳","佟",
            };
            string _seedLastName = @"吖阿啊锕嗄哎哀唉埃挨欸锿捱皑癌嗳矮蔼霭艾爱砹隘嗌嫒碍叆暧瑷僾薆餲安桉氨庵谙媕腤鹌鞍闇鮟盫啽垵俺唵埯铵揞晻犴岸按案胺暗黯肮昂枊盎醠凹坳垇爊敖嗷嶅廒獒遨熬璈翱聱螯謷鳌鏖芺袄媪岙傲奡奥骜墺澳懊鏊呆騃盦欬啀凒溰嘊敳昹躷濭譪伌硋塧壒懓懝賹鴱皧瞹馤鑀鱫侒峖萻葊痷蓭誝馣韽鶕玵雸隌罯荌豻堓婩貋錌岇昻厫隞嗸滶獓摮蔜翶鷔媼扷岰嫯慠奧澚擙謸袰厰屽垾鯦熝鏕桛泑扱滀郃繻饧夕兮汐西吸希昔析矽穸郗唏奚娭息晞浠牺悉惜欷淅烯硒菥傒晰犀稀粞翕舾溪皙锡僖熄熙蜥嘻嬉膝樨熹羲螅燨蟋谿醯曦鼷习席袭觋媳隰檄洗玺徙铣喜葸屣蓰禧鱚戏系饩细阋舄隙禊呷瞎匣侠狎峡柙狭硖遐暇瑕辖霞黠下夏罅仙先氙祆籼莶掀跹酰锨鲜暹伭闲弦贤咸涎娴舷衔痫鹇嫌冼显险猃蚬筅跣藓燹县岘苋现线限宪陷馅缐羡献腺霰乡芗相香厢湘缃葙箱襄骧镶详庠祥翔享响饷飨想鲞向巷项象像橡蟓枭削哓枵鐍脩丫压呀押鸦桠鸭牙伢岈芽厓琊蚜崖涯睚衙疋哑雅亚讶迓垭娅砑氩揠咽恹烟胭崦淹焉菸阉湮腌鄢嫣延严妍芫言岩沿炎研盐阎筵蜒颜檐兖奄俨匽衍偃厣掩眼琰罨演魇鼹厌彦砚唁宴晏艳验谚堰焰焱雁滟酽谳燕赝央泱殃秧鸯鞅扬羊阳旸杨炀佯疡徉洋烊蛘卬";
            var rnd = new Random(DateTime.Now.Millisecond);
            firstName = _seedFirstName[rnd.Next(_seedFirstName.Length - 1)];
            lasrName = _seedLastName.Substring(rnd.Next(0, _seedLastName.Length - 1), 1)
                + _seedLastName.Substring(rnd.Next(0, _seedLastName.Length - 1), 1);
            return firstName + lasrName;
            
        }
        private static void _GarbageClear()
        {
            var dbcontext = new StuDBContext();
            var students = dbcontext.Students.DistinctBy(x => x.FullName).ToList();
            foreach (var stu in students)
                dbcontext.Students.Where(x => x.FullName == stu.FullName && x.ID != stu.ID).Delete();
        }
    }
}
