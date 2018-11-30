using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace MusicStore.Migrations
{
    public class GenreSeed
    {
        private static readonly MusicStoreEntity.EntityDbContext _dbContext = new MusicStoreEntity.EntityDbContext();

        public static void Seed()
        {
            _dbContext.Database.ExecuteSqlCommand("delete albums");
            _dbContext.Database.ExecuteSqlCommand("delete artists");
            _dbContext.Database.ExecuteSqlCommand("delete genres");
            var genres = new List<Genre>()
            {
                new Genre() {Name="摇滚",Description="Rock" },
                new Genre() {Name="爵士" ,Description="Jazz"},
                new Genre() {Name="重金属",Description="Metal" },
                new Genre() {Name="慢摇" ,Description="DownTempo"},
                new Genre() {Name="蓝调",Description="Blue" },
                new Genre() {Name="拉丁",Description="Latin" },
                new Genre() {Name="流行",Description="Pop" },
                new Genre() {Name="古典" ,Description="Classical"},
                new Genre() {Name="DJ",Description="DJ" },
                new Genre() {Name="嘻哈",Description="Hihop" },
            };
            foreach (var g in genres)
                _dbContext.Genres.Add(g);
            _dbContext.SaveChanges();
            var artists = new List<Artist>()
            {
                new Artist() {Name="蔡健雅",Sex=false,Description="新加坡人，华语著名歌手、词曲作者，音乐制作人。1997年在新加坡由其经纪公司 Music & Movement 旗下的Yellow Music发行英语专辑《Bored》而正式出道，1999年将国语唱片签约于宝丽金唱片旗下，并推出首张国语同名专辑《蔡健雅》。" },
                new Artist() {Name="王以太",Sex=true,Description="cdc说唱会馆 王以太 3ho" },
                new Artist() {Name="马雨阳",Sex=true,Description="我知道我不一般，一切就都不一般。" },
                new Artist() {Name="徐秉龙",Sex=true,Description="徐秉龙，00后原创音乐人，词曲作者，南方生人。煮草文化旗下艺人，自学写歌。15岁发表第一首原创作品，16岁为林宥嘉创作单曲《船》，17岁开启七城巡演。" },
                new Artist() {Name="毛不易",Sex=true,Description="毛不易，原名王维家，1994年10月1日出生于黑龙江省齐齐哈尔市泰来县，中国内地流行乐男歌手，毕业于杭州师范大学护理专业。2017年，参加选秀娱乐节目《明日之子》的比赛，获得全国总决赛冠军，从而正式进入演艺圈；9月1日，推出首张个人音乐专辑《巨星不易工作室 No.1》；11月11日，推出个人原创单曲《项羽虞姬》。" },
                new Artist() {Name="房东的猫",Sex=false,Description="这一年去了很多城市，是时候带着新的作品回到武汉。2018年12月31日，房东的猫武汉跨年演唱会——「白」" },
                new Artist() {Name="许嵩",Sex=true,Description="著名作词人、作曲人、唱片制作人、歌手。内地独立音乐之标杆人物，有音乐鬼才之称。" },
                new Artist() {Name="张学友",Sex=true,Description="在亚洲地区和整个华人社会具有影响力的实力派音乐巨星和著名电影演员，香港乐坛“四大天王”之一，在华语地区享有“歌神”的美誉。90年代中期为张学友事业巅峰时期，根据IFPI国际唱片协会统计，张学友的唱片销量仅次于当时如日中天的已故美国歌手迈克尔·杰克逊，当时排名世界第二。" },
                new Artist() {Name="田馥甄",Sex=false,Description="田馥甄，艺名Hebe，台湾知名女艺人，女子演唱团体S.H.E组合成员，出生于台湾新竹县新丰乡，于2000年参加“宇宙2000实力美少女争霸战”选秀活动，并于同年与宇宙唱片（华研唱片前身）签约培训，接着在隔年与Selina、Ella组成S.H.E，并于2001年9月11日发行S.H.E首张专辑《女生宿舍》正式出道。" },
                new Artist() {Name="张国荣",Sex=true,Description="张国荣是一位在全球华人社会和亚洲地区具有影响力的著名歌手、演员和音乐人；大中华区乐坛和影坛巨星；演艺圈多栖发展最成功的代表之一。张国荣是香港乐坛的殿堂级歌手之一，曾获得香港乐坛最高荣誉金针奖；他是第一位享誉韩国乐坛的华人歌手，亦是华语唱片在韩国销量纪录保持者。" },
                new Artist() {Name="胡彦斌",Sex=true,Description="胡彦斌 （Tiger Hu） ，男，1983年7月生于上海，著名歌手、创作人、制作人。 2000年，推出个人首支单曲《玛丽莲梦露》，主唱动画片《我为歌狂》相关歌曲。" },
                new Artist() {Name="徐佳莹",Sex=false,Description="华语流行音乐创作女歌手、金曲奖得主。1984年12月20日生于台湾台中市，籍贯四川省简阳县。" },
                new Artist() {Name="米津玄師",Sex=true,Description="米津玄师（1991年3月10日－），是日本的音乐家、创作歌手、插画家、摄影师。出生于德岛县德岛市。血型O型。另有发表笔名“Hachi（ハチ）”。在第57回日本唱片大奖获得优秀专辑奖。" },
                //new Artist {Name="U2" },
                //new Artist {Name="The Police" },
                //new Artist {Name="The Who" },
                //new Artist {Name="Tim Maia" },
                //new Artist {Name="Van Halen" },
                //new Artist {Name="Wilhelm Kempff" },
                //new Artist {Name="Zeca Pagodinho" },
                //new Artist {Name="Velvet Revolver" },
                //new Artist {Name="Rush" },
                //new Artist {Name="Santana" },
                //new Artist {Name="Fretwork" },
                //new Artist {Name="Incognito" },
                //new Artist {Name="Joe Satriani" },
            };
            foreach (var a in artists)
                _dbContext.Artists.Add(a);
            _dbContext.SaveChanges();
            new List<Album>
            {
                new Album
                {
                    Title ="失语者",Genre=genres.Single(g=>g.Name == "摇滚"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif"
                },

                new Album {Title="PUMA",Genre=genres.Single(g=>g.Name=="摇滚"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="王以太"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="那时的我们",Genre=genres.Single(g=>g.Name=="摇滚"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="毛不易"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="停格",Genre=genres.Single(g=>g.Name=="摇滚"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="爱了很久的朋友",Genre=genres.Single(g=>g.Name=="摇滚"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="田馥甄"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="一江水",Genre=genres.Single(g=>g.Name=="爵士"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="徐佳莹"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="云烟成雨",Genre=genres.Single(g=>g.Name=="爵士"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="房东的猫"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="宝藏男友",Genre=genres.Single(g=>g.Name=="爵士"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="胡彦斌"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="オルゴールコレクション-Lemon-",Genre=genres.Single(g=>g.Name=="爵士"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="米津玄師"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="云烟成雨",Genre=genres.Single(g=>g.Name=="爵士"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="房东的猫"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="毫无惊喜的一万多天",Genre=genres.Single(g=>g.Name=="重金属"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="马雨阳"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="用余生去爱",Genre=genres.Single(g=>g.Name=="重金属"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="张学友"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="停格",Genre=genres.Single(g=>g.Name=="重金属"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="至此",Genre=genres.Single(g=>g.Name=="重金属"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="房东的猫"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="有何不可",Genre=genres.Single(g=>g.Name=="重金属"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="许嵩"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="有何不可",Genre=genres.Single(g=>g.Name=="慢摇"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="许嵩"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="用余生去爱",Genre=genres.Single(g=>g.Name=="慢摇"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="张学友"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="停格",Genre=genres.Single(g=>g.Name=="慢摇"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="有何不可",Genre=genres.Single(g=>g.Name=="慢摇"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="许嵩"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="Lemon",Genre=genres.Single(g=>g.Name=="慢摇"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="米津玄師"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="Lemon",Genre=genres.Single(g=>g.Name=="蓝调"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="米津玄師"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="停格",Genre=genres.Single(g=>g.Name=="蓝调"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="至此",Genre=genres.Single(g=>g.Name=="蓝调"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="房东的猫"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="零零",Genre=genres.Single(g=>g.Name=="蓝调"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="徐秉龙"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="停格",Genre=genres.Single(g=>g.Name=="蓝调"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="停格",Genre=genres.Single(g=>g.Name=="拉丁"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="零零",Genre=genres.Single(g=>g.Name=="拉丁"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="徐秉龙"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="至此",Genre=genres.Single(g=>g.Name=="拉丁"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="房东的猫"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="停格",Genre=genres.Single(g=>g.Name=="拉丁"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="零零",Genre=genres.Single(g=>g.Name=="拉丁"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="徐秉龙"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="毫无惊喜的一万多天",Genre=genres.Single(g=>g.Name=="流行"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="马雨阳"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                 new Album {Title="说到爱",Genre=genres.Single(g=>g.Name=="流行"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="三思而后行",Genre=genres.Single(g=>g.Name=="流行"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="王以太"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="停格",Genre=genres.Single(g=>g.Name=="流行"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="停格",Genre=genres.Single(g=>g.Name=="流行"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="说到爱",Genre=genres.Single(g=>g.Name=="古典"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                 new Album {Title="Lemon",Genre=genres.Single(g=>g.Name=="古典"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="米津玄師"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="说到爱",Genre=genres.Single(g=>g.Name=="古典"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="一江水",Genre=genres.Single(g=>g.Name=="古典"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="徐佳莹"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="说到爱",Genre=genres.Single(g=>g.Name=="古典"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="说到爱",Genre=genres.Single(g=>g.Name=="DJ"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                 new Album {Title="一江水",Genre=genres.Single(g=>g.Name=="DJ"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="徐佳莹"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="说到爱",Genre=genres.Single(g=>g.Name=="DJ"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="爱了很久的朋友",Genre=genres.Single(g=>g.Name=="DJ"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="田馥甄"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="梅香如故",Genre=genres.Single(g=>g.Name=="DJ"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="毛不易"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="说到爱",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                 new Album {Title="毫无惊喜的一万多天",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="马雨阳"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="说到爱",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="蔡健雅"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="梅香如故",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="毛不易"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="毫无惊喜的一万多天",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="马雨阳"),AlbumArtUrl="/Content/Images/placeholder.gif" },
                new Album {Title="爱了很久的朋友",Genre=genres.Single(g=>g.Name=="嘻哈"),Price=8.99M,
                    Artist =artists.Single(a=>a.Name=="田馥甄"),AlbumArtUrl="/Content/Images/placeholder.gif" },
            }.ForEach(n => _dbContext.Albums.Add(n));
            _dbContext.SaveChanges();
        }

        public static void Extend()
        {
            var albums = _dbContext.Albums.ToList();
            foreach (var album in albums)
            {
                var item = _dbContext.Albums.Find(album.ID);
                item.Genreid = item.Genre.ID.ToString();
                item.Artistid = item.Artist.ID.ToString();
                _dbContext.SaveChanges();
                Thread.Sleep(3);
            }
        }
        }
    }