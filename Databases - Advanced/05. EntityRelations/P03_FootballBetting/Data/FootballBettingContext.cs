namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;

    using Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
            : base()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.OnTeamCreating(modelBuilder);

            this.OnColorCreating(modelBuilder);

            this.OnTownCreating(modelBuilder);

            this.OnCountryCreating(modelBuilder);

            this.OnPlayerCreating(modelBuilder);

            this.OnPositionCreating(modelBuilder);

            this.OnPlayerStatisticCreating(modelBuilder);

            this.OnGameCreating(modelBuilder);

            this.OnBetCreating(modelBuilder);

            this.OnUserCreating(modelBuilder);
        }

        private void OnUserCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("Users");

                user.HasKey(u => u.UserId);
            });
        }

        private void OnBetCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>(bet =>
            {
                bet.ToTable("Bets");

                bet.HasKey(b => b.BetId);

                bet.HasOne(b => b.User)
                    .WithMany(u => u.Bets)
                    .HasForeignKey(b => b.UserId);

                bet.HasOne(b => b.Game)
                    .WithMany(g => g.Bets)
                    .HasForeignKey(b => b.GameId);
            });
        }

        private void OnGameCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(game =>
            {
                game.ToTable("Games");

                game.HasKey(g => g.GameId);

                game.HasOne(g => g.HomeTeam)
                    .WithMany(t => t.HomeGames)
                    .HasForeignKey(g => g.HomeTeamId);

                game.HasOne(g => g.AwayTeam)
                    .WithMany(t => t.AwayGames)
                    .HasForeignKey(g => g.AwayTeamId);
            });
        }

        private void OnPlayerStatisticCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(playerStatistic => 
            {
                playerStatistic.ToTable("PlayerStatistics");

                playerStatistic.HasKey(ps => new { ps.GameId, ps.PlayerId });

                playerStatistic.HasOne(ps => ps.Game)
                    .WithMany(g => g.PlayerStatistics)
                    .HasForeignKey(ps => ps.GameId);

                playerStatistic.HasOne(ps => ps.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(ps => ps.PlayerId);
            });
        }

        private void OnPositionCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>(position =>
            {
                position.ToTable("Positions");

                position.HasKey(p => p.PositionId);
            });
        }

        private void OnPlayerCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(player => 
            {
                player.ToTable("Players");

                player.HasKey(p => p.PlayerId);

                player.HasOne(p => p.Team)
                    .WithMany(t => t.Players)
                    .HasForeignKey(p => p.TeamId);

                player.HasOne(pl => pl.Position)
                    .WithMany(po => po.Players)
                    .HasForeignKey(pl => pl.PositionId);
            });
        }

        private void OnCountryCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(country =>
            {
                country.ToTable("Countries");

                country.HasKey(c => c.CountryId);
            });
        }

        private void OnTownCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Town>(town => 
            {
                town.ToTable("Towns");

                town.HasKey(t => t.TownId);

                town.HasOne(t => t.Country)
                    .WithMany(c => c.Towns)
                    .HasForeignKey(t => t.CountryId);
            });
        }

        private void OnColorCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>(color =>
            {
                color.ToTable("Colors");

                color.HasKey(c => c.ColorId);
            });
        }

        private void OnTeamCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(team =>
            {
                team.ToTable("Teams");

                team.HasKey(t => t.TeamId);

                team.HasOne(t => t.PrimaryKitColor)
                    .WithMany(c => c.PrimaryKitTeams)
                    .HasForeignKey(t => t.PrimaryKitColorId);

                team.HasOne(t => t.SecondaryKitColor)
                    .WithMany(c => c.SecondaryKitTeams)
                    .HasForeignKey(t => t.PrimaryKitColorId);

                team.HasOne(te => te.Town)
                    .WithMany(to => to.Teams)
                    .HasForeignKey(te => te.TownId);
            });
        }
    }
}
