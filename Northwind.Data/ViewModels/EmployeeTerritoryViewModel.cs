using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Northwind.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class EmployeeTerritoryViewModel : ZViewBase<EmployeeTerritoryViewModel, EmployeeTerritoryDTO, EmployeeTerritory>
    {
        #region Properties
        
        [Display(Name = "PropertyEmployeeId", ResourceType = typeof(EmployeeTerritoryResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        //[Column(Order=1)]
        [Range(1, Int32.MaxValue)]
        [Required]
        public virtual int EmployeeId { get; set; }
        
        [Display(Name = "PropertyTerritoryId", ResourceType = typeof(EmployeeTerritoryResources))]
        //[Key]
        //[Column(Order=2)]
        [Required]
        [StringLength(20)]
        public virtual string TerritoryId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string EmployeeLookupText { get; set; } // EmployeeId

        public virtual string TerritoryLookupText { get; set; } // TerritoryId
    
        #endregion Associations FK

        #region Properties ZViewBase

        public override string LookupText { get; set; }

        #endregion Properties ZViewBase

        #region Methods
        
        public EmployeeTerritoryViewModel()
        {
            EmployeeId = 1;
            TerritoryId = "A";
        }
        
        public EmployeeTerritoryViewModel(
            int employeeId,
            string territoryId,
            string employeeLookupText = null,
            string territoryLookupText = null
        )
            : this()
        {
            EmployeeId = employeeId;
            TerritoryId = territoryId;
            EmployeeLookupText = employeeLookupText;
            TerritoryLookupText = territoryLookupText;
        }

        public EmployeeTerritoryViewModel(IZDataBase data)
        {
            FromData(data);
        }

        public EmployeeTerritoryViewModel(IZDTOBase<EmployeeTerritoryDTO, EmployeeTerritory> dto)
        {
            FromDTO(dto);
        }

        #endregion Methods

        #region Methods ZViewBase

        public override Func<EmployeeTerritoryViewModel, EmployeeTerritoryDTO> GetDTOSelector()
        {
            return x => new EmployeeTerritoryDTO
            {
                EmployeeId = x.EmployeeId,
                TerritoryId = x.TerritoryId,
                EmployeeLookupText = x.EmployeeLookupText,
                TerritoryLookupText = x.TerritoryLookupText,
                LookupText = x.LookupText
            };
        }

        public override Func<EmployeeTerritoryDTO, EmployeeTerritoryViewModel> GetViewSelector()
        {
            return x => new EmployeeTerritoryViewModel
            {
                EmployeeId = x.EmployeeId,
                TerritoryId = x.TerritoryId,
                EmployeeLookupText = x.EmployeeLookupText,
                TerritoryLookupText = x.TerritoryLookupText,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                EmployeeTerritoryDTO dto = new EmployeeTerritoryDTO(data);
                EmployeeTerritoryViewModel view = (new List<EmployeeTerritoryDTO> { (EmployeeTerritoryDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);            
            }
        }

        public override void FromDTO(IZDTOBase<EmployeeTerritoryDTO, EmployeeTerritory> dto)
        {
            if (dto != null)
            {
                EmployeeTerritoryViewModel view = (new List<EmployeeTerritoryDTO> { (EmployeeTerritoryDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);
            }
        }

        public override IZDataBase ToData()
        {
            return ToDTO().ToData();
        }
        
        public override IZDTOBase<EmployeeTerritoryDTO, EmployeeTerritory> ToDTO()
        {
            return (new List<EmployeeTerritoryViewModel> { this })
                .Select(GetDTOSelector())
                .SingleOrDefault();   
        }
        
        #endregion Methods ZViewBase
    }
}
