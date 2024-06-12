using Inforce.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inforce.Persistence.Contexts.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Name)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(u => u.Password)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(u => u.CreationDate)
                .IsRequired()
                .HasColumnType("TEXT");

        }
    }
}