using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Browl.Service.DataNormalization.Domain.Entities;
using Browl.Service.DataNormalization.Domain.ValueObjects;

namespace Browl.Service.DataNormalization.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<PackingList>, IEntityTypeConfiguration<PackingItem>
    {
        public void Configure(EntityTypeBuilder<PackingList> builder)
        {
            builder.HasKey(pl => pl.Id);

            var localizationConverter = new ValueConverter<Localization, string>(l => l.ToString(),
                l => Localization.Create(l));

            var packingListNameConverter = new ValueConverter<PackingListName, string>(pln => pln.Value,
                pln => new PackingListName(pln));

            builder
                .Property(pl => pl.Id)
                .HasConversion(id => id.Value, id => new PackingListId(id));

            builder
                .Property(typeof(Localization), "_localization")
                .HasConversion(localizationConverter)
                .HasColumnName("Localization");

            builder
                .Property(typeof(PackingListName), "_name")
                .HasConversion(packingListNameConverter)
                .HasColumnName("Name");

            builder.HasMany(typeof(PackingItem), "_items");

            builder.ToTable("PackingLists");
        }

        public void Configure(EntityTypeBuilder<PackingItem> builder)
        {
            builder.Property<Guid>("Id");
            builder.Property(pi => pi.Name);
            builder.Property(pi => pi.Quantity);
            builder.Property(pi => pi.IsPacked);
            builder.ToTable("PackingItems");
        }
    }
}