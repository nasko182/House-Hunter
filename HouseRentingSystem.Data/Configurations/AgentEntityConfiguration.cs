namespace HouseRentingSystem.Data.Configurations;
using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Models;

public class AgentEntityConfiguration : IEntityTypeConfiguration<Agent>
{
    public void Configure(EntityTypeBuilder<Agent> builder)
    {
        builder.HasData(this.GenerateAgents());
    }

    private Agent[] GenerateAgents()
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

        return agents.ToArray();
    }
}
