namespace HouseRentingSystem.Data.Configurations;
using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Models;

public class AgentEntityConfiguration : IEntityTypeConfiguration<Agent>
{
    public void Configure(EntityTypeBuilder<Agent> builder)
    {
        builder.HasData(GenerateAgents());
    }

    private static Agent[] GenerateAgents()
    {
        ICollection<Agent> agents = new HashSet<Agent>();
        Agent agent;

        agent = new Agent
        {
            Id = Guid.Parse("ACE3AB43-264E-4B2D-B56D-274170BACFC5"),
            PhoneNumber = "+359888888888",
            UserId = Guid.Parse("2FE36ACB-8C75-42D4-C03D-08DC1FF94547")
        };
        agents.Add(agent);

        agent = new Agent
        {
            Id = Guid.Parse("6A347F29-0054-40EC-9F7A-1099D214430E"),
            PhoneNumber = "+359888888887",
            UserId = Guid.Parse("50C9CAF6-B29D-40BB-805B-60B2239C658D")
        };
        agents.Add(agent);

        return agents.ToArray();
    }
}
