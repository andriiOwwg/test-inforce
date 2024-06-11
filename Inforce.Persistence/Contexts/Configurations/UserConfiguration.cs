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
            
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasColumnType("TEXT");
            
            builder.Property(u => u.LastName)
                .IsRequired()
                .HasColumnType("TEXT");
            
            builder.Property(u => u.UserSurname)
                .IsRequired()
                .HasColumnType("TEXT");


            builder.Property(u => u.AccountStatusId)
                .HasColumnType("TEXT");


            builder.Property(u => u.AccountStatus)
                .IsRequired()
                .HasColumnType("INTEGER");


            builder.Property(u => u.CreationDate)
                .IsRequired()
                .HasColumnType("TEXT");
            
        }
    }
}