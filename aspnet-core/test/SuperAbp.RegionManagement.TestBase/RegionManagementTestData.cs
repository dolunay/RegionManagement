using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SuperAbp.RegionManagement;

public class RegionManagementTestData : ISingletonDependency
{
    public Guid Province1Id { get; } = Guid.NewGuid();
    public string Province1Name { get; } = "河北省";
    public string Province1Code { get; } = "13";
    public Guid Province2Id { get; } = Guid.NewGuid();
    public string Province2Name { get; } = "山东省";
    public string Province2Code { get; } = "37";
    public Guid City1Id { get; } = Guid.NewGuid();
    public string City1Name { get; } = "邢台市";
    public string City1Code { get; } = "1305";
    public Guid City2Id { get; } = Guid.NewGuid();
    public string City2Name { get; } = "烟台市";
    public string City2Code { get; } = "3706";
    public Guid District1Id { get; } = Guid.NewGuid();
    public string District1Name { get; } = "临西县";
    public string District1Code { get; } = "130535";
    public Guid District2Id { get; } = Guid.NewGuid();
    public string District2Name { get; } = "广宗县";
    public string District2Code { get; } = "130531";
    public Guid Street1Id { get; } = Guid.NewGuid();
    public string Street1Name { get; } = "老官寨镇";
    public string Street1Code { get; } = "130535104";
    public Guid Street2Id { get; } = Guid.NewGuid();
    public string Street2Name { get; } = "摇鞍镇乡";
    public string Street2Code { get; } = "130535203";
    public Guid Village1Id { get; } = Guid.NewGuid();
    public string Village1Name { get; } = "东水波村委会";
    public string Village1Code { get; } = "130535104221";
    public Guid Village2Id { get; } = Guid.NewGuid();
    public string Village2Name { get; } = "前寨村委会";
    public string Village2Code { get; } = "130535104209";
}