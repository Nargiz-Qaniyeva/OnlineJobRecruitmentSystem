using Jobbply__Final_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jobbply__Final_Project.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<Timers> Timers { get; set; }
        public DbSet<PosterTimes> PosterTimes { get; set; }



        //public DbSet<Post> Post { get; set; }
        //public DbSet<Times> Time { get; set; }
        //public DbSet<PostTimes> PostTimes { get; set; }

        public DbSet<SendMessage>  sendMessages { get; set; }
        public DbSet<Testimonial_Slider> Testimonial_Sliders { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<PageIntro> PageIntros { get; set; }
        public DbSet<Specializm> Specializms { get; set; }
        public DbSet<JobStatistics> JobStatistics { get; set; }
        public DbSet<Candidates> Candidates { get; set; }
        public DbSet<BlogTitle> BlogTitles { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<AvailableJob> AvailableJobs { get; set; }
        public DbSet<RecruitmentAgencies> RecruitmentAgencies { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Welcome> Welcomes { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BlogPage> BlogPages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<BlogOtherAbout> BlogOtherAbouts { get; set; }
        public DbSet<BlogOther> BlogOthers { get; set; }
        public DbSet<AuthorBlog> AuthorBlogs { get; set; }
        public DbSet<Widget> Widgets { get; set; }
        public DbSet<Coomments> Coomments { get; set; }
        public DbSet<Find> Finds { get; set; }
        
        public DbSet<ClientSlider> ClientSliders { get; set; }
        public DbSet<GetTouch> GetTouches { get; set; }
        public DbSet<JobInfo> jobInfos { get; set; }
        public DbSet<TopCategory> topCategories { get; set; }
        public DbSet<Shortlist> shortlists { get; set; }
    }
}
