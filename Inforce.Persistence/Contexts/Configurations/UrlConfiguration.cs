using Inforce.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inforce.Persistence.Contexts.Configurations;

public class UrlConfiguration: IEntityTypeConfiguration<Url>
{
    public void Configure(EntityTypeBuilder<Url> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
            
        builder.Property(u => u.CreatedBy)
            .IsRequired()
            .HasColumnType("TEXT");
            
        builder.Property(u => u.ShortUrl)
            .IsRequired()
            .HasColumnType("TEXT");
            
        builder.Property(u => u.LongUrl)
            .IsRequired()
            .HasColumnType("TEXT");
        
        builder.Property(u => u.CreationDate)
            .IsRequired()
            .HasColumnType("TEXT");
            
    }
}