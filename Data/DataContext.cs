using Microsoft.EntityFrameworkCore;
using PURE.Models;

namespace PURE.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        public DbSet<EventoMock> EventosMock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<EventoMock>().HasData(

                new EventoMock()
                {

                    Id = 1,
                    EventName = "Limpeza Praia do Cassino",
                    Description = "Nesse encontro vamos fazer o máximo para limpar a nossa praia do cassino, contamos com voce!",
                    EventLocal = "Praia do Cassino, RS",
                    EventDate = "05/06/2024",
                    InitialEventTime = "08:00",
                    EventPoint = 160

                },

                new EventoMock()
                {
                    Id = 2,
                    EventName = "Limpando a praia já!",
                    Description = "Contamos com a ajuda de todos para que conseguimos limpar a praia e voltar sua beleza",
                    EventLocal = "Praia Bertioga, SP",
                    EventDate = "31/05/2024",
                    InitialEventTime = "12:00",
                    EventPoint = 90

                },
                new EventoMock()
                {

                    Id = 3,
                    EventName = "Deixando a praia limpa!",
                    Description = "Queremos deixar nossa praia o mais limpa possivel, venha ajudar a salvar o oceano conosco!!",
                    EventLocal = "Praia de Trindade, RJ",
                    EventDate = "12/02/2024",
                    InitialEventTime = "09:00",
                    EventPoint = 125

                }

            );

        }
    }
}
