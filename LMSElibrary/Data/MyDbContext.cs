using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SubjectService.Model;

namespace SubjectService.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region
        public DbSet<MonHoc> monHocs { get; set; }
        public DbSet<BoMon> boMons { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<ChuDe> chuDes { get; set; }
        public DbSet<BaiGiang> baiGiangs { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<DanhsachLop> danhsachLops { get; set; }
     public DbSet<ChiTietBaiGiang> chitietbaiGiang { get; set; }
       //public DbSet<ChitietLop> chitietLop { get; set; }
        public DbSet<ThongtinMonHoc> thongtinMonhoc { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonHoc>(sub =>
            {
                sub.HasOne(e => e.BoMon).
                 WithMany(e => e.MonHocs)
                .HasConstraintName("FK_MonHoc_BoMon")
                .HasForeignKey(e => e.IdBoMon);
            }
            ) ;

            modelBuilder.Entity<ThongtinMonHoc>(t =>

               t.HasOne(e => e.monHoc).
                  WithMany(e => e.ttmh)
                 .HasConstraintName("FK_ttmh_monhoc")
                 .HasForeignKey(e => e.IdMonHoc)
           );

         

            modelBuilder.Entity<ChuDe>(tp =>
            {
                tp.HasOne(e => e.monHoc).
                   WithMany(e => e.topics)
                  .HasConstraintName("FK_chude_monhoc")
                  .HasForeignKey(e => e.IdMonHoc);
            });

            modelBuilder.Entity<BaiGiang>(dc =>
            {

                dc.HasOne(e => e.chuDe).
                   WithMany(e => e.documents)
                  .HasConstraintName("FK_baigiang_chude")
                  .HasForeignKey(e => e.IdChuDe);

               
            });

            modelBuilder.Entity<Resources>(tp =>
            {

                tp.HasOne(e => e.baiGiang).
                   WithMany(e => e.resources)
                  .HasConstraintName("FK_res_baigiang")
                  .HasForeignKey(e => e.IdBaiGiang);
            });

            //modelBuilder.Entity<ChitietLop>(ct =>
            //{
            //    ct.ToTable("ChiTietLop");
            //    ct.HasKey(t => new { t.IdLop, t.IdMonHoc });

            //   // ct.HasOne(e => e.monHoc).
            //   //    WithMany(e => e.ctlop)
            //   //   .HasConstraintName("FK_ctlop_monhoc")
            //   //   .HasForeignKey(e => e.IdMonHoc);

            //   // ct.HasOne(e => e.lop).
            //   // WithMany(e => e.ctlop)
            //   //.HasConstraintName("FK_ctlop_lop")
            //   //.HasForeignKey(e => e.IdLop);
            //});

            modelBuilder.Entity<ChiTietBaiGiang>(ct =>
            {
                ct.ToTable("ChitietBaiGiang");
                ct.HasKey(t => new { t.IdLop, t.IdBaiGiang });

               // ct.HasOne(e => e.baiGiang).
               //    WithMany(e => e.ctbg)
               //   .HasConstraintName("FK_ctbaigiang_baigiang")
               //   .HasForeignKey(e => e.IdBaiGiang);

               // ct.HasOne(e => e.lop).
               // WithMany(e => e.ctbg)
               //.HasConstraintName("FK_ctbg_lop")
               //.HasForeignKey(e => e.IdLop);
            });


            modelBuilder.Entity<DanhsachLop>(t =>
            {

                t.HasOne(e => e.lop).
                   WithMany(e => e.dslop)
                  .HasConstraintName("FK_dslop_lop")
                  .HasForeignKey(e => e.IdLop);
            });


        }
    }
}
