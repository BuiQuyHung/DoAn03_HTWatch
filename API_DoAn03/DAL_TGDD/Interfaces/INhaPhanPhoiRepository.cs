﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models_TGDD;

namespace DAL_TGDD.Interfaces
{
    public partial interface INhaPhanPhoiRepository
    {
        IEnumerable<NhaPhanPhoiModel> GetAllData();
        NhaPhanPhoiModel GetDatabyID(string MaNPP);
        bool Create(NhaPhanPhoiModel model);
        bool Update(NhaPhanPhoiModel model);
        bool Delete(string MaNPP);
        public List<NhaPhanPhoiModel> Search(int pageIndex, int pageSize, out long total, string ma_npp, string ten_npp);
    }
}
