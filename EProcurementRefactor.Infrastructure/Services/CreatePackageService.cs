using EProcurementRefactor.Application.DTOs;
using EProcurementRefactor.Application.Interfaces;
using EProcurementRefactor.Domain.Entities;
using EProcurementRefactor.Domian.Enums;

namespace EProcurementRefactor.Infrastructure.Services
{
    public class CreatePackageService : ICreatePackageService
    {
        private readonly IGenericPackagesRepo<PackagesHeader> _packageHeaderRepo;
        private readonly IGenericPackagesRepo<PackagesDetail> _packageDetailsRepo;
        private readonly IUnitOfWork _unitOfWork;
        public CreatePackageService(
            IGenericPackagesRepo<PackagesHeader> packageHeaderRepo,
            IGenericPackagesRepo<PackagesDetail> packageDetailsRepo,
            IUnitOfWork unitOfWork)
        {
            _packageHeaderRepo = packageHeaderRepo;
            _packageDetailsRepo = packageDetailsRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> CreateMaterialPackage(
            CreateMaterialPackageDto createMaterialPackageDto,
            CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransaction(cancellationToken);

                int returnedvalue = 0;
                var result = await MappingCommonPackageProperities(createMaterialPackageDto,false);
                var materialPackageHeader = result.CommonPackageHeader;

                materialPackageHeader.credit_period = createMaterialPackageDto.credit_period;

                materialPackageHeader.credit_periodType = Enum.TryParse<PeriodType>(
                                        createMaterialPackageDto.credit_periodType,
                                        true,
                                        out var cPeriodType)
                                        && Enum.IsDefined(typeof(PeriodType), cPeriodType)
                                            ? cPeriodType
                                            : null;

                materialPackageHeader.delivery_duration = createMaterialPackageDto.delivery_duration;

                materialPackageHeader.delivery_durationType = Enum.TryParse<PeriodType>(
                                        createMaterialPackageDto.delivery_durationType,
                                        true,
                                        out var dPeriodType)
                                        && Enum.IsDefined(typeof(PeriodType), dPeriodType)
                                            ? dPeriodType
                                            : null;

                var selectedRows = createMaterialPackageDto.selected_rows
                .Distinct()
                .ToList();

                var packageDetailsList = selectedRows
                    .Select(item => new PackagesDetail
                    {
                        pr_num = item.pr,
                        pr_date = DateOnly.ParseExact(
                            item.pr_req_date, "d-M-yyyy", null),
                        mtr_uom = item.m_uom,
                        mtr_code = item.mat_code,
                        m_grp = item.m_grp,
                        mtr_batch = item.m_batch,
                        mtr_desc = item.mat_desc,
                        line_item = item.pr_item,
                        mtr_qty = item.m_req_qty,
                        mtr_long_desc = item.m_long_desc,
                        user_id = 0,
                        pkg = materialPackageHeader
                    })
                    .ToList();

                await _packageHeaderRepo.AddAsync(materialPackageHeader);
                await _packageDetailsRepo.AddRangeAsync(packageDetailsList);

                //var sapStatusDTOList = selectedRows
                //    .Select(item => new SapStatusDto
                //    {
                //        EPACKAGE = materialPackageHeader.PkgName,
                //        PR = item.Pr,
                //        ITEM = int.Parse(item.PrItem),
                //        industry = result.industryResult,
                //        STATUS = "Automatic-Released"
                //    })
                //    .ToList();

                returnedvalue = await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitTransaction(cancellationToken);

                return returnedvalue;
            }
            catch
            {
                await _unitOfWork.RollBackTransaction(cancellationToken);
                throw;
            }            
        }

        public async Task<int> CreateServicePackage(
            CreateServicePackageDto createServicePackageDto,
            CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransaction(cancellationToken);

                int returnedvalue = 0;
                var result = await MappingCommonPackageProperities(createServicePackageDto,true);

                var servicePackageHeader = result.CommonPackageHeader;

                servicePackageHeader.execution_duration = createServicePackageDto.execution_duration;
                servicePackageHeader.execution_durationType =
                                    createServicePackageDto.execution_durationType.HasValue &&
                                    Enum.IsDefined(typeof(PeriodType), createServicePackageDto.execution_durationType.Value)
                                        ? (PeriodType?)createServicePackageDto.execution_durationType.Value
                                        : null;

                servicePackageHeader.is_service = true;

                await _packageHeaderRepo.AddAsync(servicePackageHeader);

                var selectedRows = createServicePackageDto.selected_rows
                .Distinct()
                .ToList();

                var packageDetailsList = selectedRows.Select(e =>
                new PackagesDetail
                {
                    pr_num = e.PR,
                    pr_date = DateOnly.ParseExact(e.PR_REQ_DATE, "d-M-yyyy", null),
                    mtr_uom = e.S_UNIT,
                    mtr_code = e.SER_CODE,
                    m_grp = e.S_GRP,
                    mtr_desc = e.SER_DESC,
                    line_item = e.PR_ITEM,
                    mtr_qty= e.S_REQ_QTY,
                    mtr_long_desc = e.S_LON_DES,
                    user_id = 0,
                    pkg = servicePackageHeader
                }).ToList();

                await _packageDetailsRepo.AddRangeAsync(packageDetailsList);
                returnedvalue = await _unitOfWork.SaveChangesAsync(cancellationToken);
                await _unitOfWork.CommitTransaction(cancellationToken);
                return returnedvalue;
            }
            catch
            {
                await _unitOfWork.RollBackTransaction(cancellationToken);
                throw;
            }
        }

        public async Task<int> CreateMaterialPackageManual(
            CreateMaterialPackageManualDTO createMaterialPackageManualDTO,
            CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransaction(cancellationToken);
                int returnedvalue = 0;

                var result = await MappingCommonPackageProperities(createMaterialPackageManualDTO,false);

                var materialPackageHeader = result.CommonPackageHeader;

                materialPackageHeader.credit_period = createMaterialPackageManualDTO.credit_period;

                materialPackageHeader.credit_periodType = Enum.TryParse<PeriodType>(
                                        createMaterialPackageManualDTO.credit_periodType,
                                        true,
                                        out var cPeriodType)
                                        && Enum.IsDefined(typeof(PeriodType), cPeriodType)
                                            ? cPeriodType
                                            : null;

                materialPackageHeader.delivery_duration = createMaterialPackageManualDTO.delivery_duration;

                materialPackageHeader.delivery_durationType = Enum.TryParse<PeriodType>(
                                        createMaterialPackageManualDTO.delivery_durationType,
                                        true,
                                        out var dPeriodType)
                                        && Enum.IsDefined(typeof(PeriodType), dPeriodType)
                                            ? dPeriodType
                                            : null;

                await _packageHeaderRepo.AddAsync(materialPackageHeader);

                var selected_rows = createMaterialPackageManualDTO.selected_rows
                     .Distinct()
                     .ToList();

                var packageDetailsList = selected_rows
                    .SelectMany(PR => createMaterialPackageManualDTO.user_ids
                        .Zip(createMaterialPackageManualDTO.risk_realisms,
                        (userId, risk) => new PackagesDetail
                        {
                            pr_num = PR.pr,
                            pr_date = DateOnly.ParseExact(
                                            PR.pr_req_date, "d-M-yyyy", null),
                            mtr_uom = PR.m_uom,
                            mtr_code = PR.mat_code,
                            m_grp = PR.m_grp,
                            mtr_batch = PR.m_batch,
                            mtr_desc = PR.mat_desc,
                            line_item = PR.pr_item,
                            mtr_qty = PR.m_req_qty,
                            mtr_long_desc = PR.m_long_desc,
                            risk_realism = risk,
                            user_id = userId,
                            pkg = materialPackageHeader
                        })).ToList();

                await _packageDetailsRepo.AddRangeAsync(packageDetailsList);

                returnedvalue = await _unitOfWork.SaveChangesAsync(cancellationToken);

                await _unitOfWork.CommitTransaction(cancellationToken);

                return returnedvalue;
            }
            catch
            {
                await _unitOfWork.RollBackTransaction(cancellationToken);
                throw;
            } 
        }
        public async Task<int> CreateServicePackageManual(
            CreateServicePackageManualDTO createServicePackageManualDTO,
            CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransaction(cancellationToken);
                int returnedvalue = 0;

                var result = await MappingCommonPackageProperities(createServicePackageManualDTO,true);

                var servicePackageHeader = result.CommonPackageHeader;

                servicePackageHeader.execution_duration = createServicePackageManualDTO.execution_duration;

                servicePackageHeader.execution_durationType = Enum.TryParse<PeriodType>(
                                        createServicePackageManualDTO.execution_durationType,
                                        true,
                                        out var ePeriodType)
                                        && Enum.IsDefined(typeof(PeriodType), ePeriodType)
                                            ? ePeriodType
                                            : null;

                servicePackageHeader.is_service = true;

                await _packageHeaderRepo.AddAsync(servicePackageHeader);

                var selected_rows = createServicePackageManualDTO.selected_rows
                     .Distinct()
                     .ToList();

                var packageDetailsList = selected_rows
                    .SelectMany(PR => createServicePackageManualDTO.user_ids
                        .Zip(createServicePackageManualDTO.risk_realisms,
                        (userId, risk) => new PackagesDetail
                        {
                            pr_num = PR.PR,
                            pr_date = DateOnly.ParseExact(
                                                PR.PR_REQ_DATE,
                                                "d-M-yyyy",
                                                null
                                            ),
                            mtr_uom = PR.S_UNIT,
                            mtr_code = PR.SER_CODE,
                            m_grp = PR.S_GRP,
                            mtr_desc = PR.SER_DESC,
                            line_item = PR.PR_ITEM,
                            mtr_qty = PR.S_REQ_QTY,
                            mtr_long_desc = PR.S_LON_DES,
                            risk_realism = risk,
                            user_id = userId,
                            pkg = servicePackageHeader
                        })).ToList();

                await _packageDetailsRepo.AddRangeAsync(packageDetailsList);

                returnedvalue = await _unitOfWork.SaveChangesAsync(cancellationToken);

                await _unitOfWork.CommitTransaction(cancellationToken);

                return returnedvalue;
            }
            catch
            {
                await _unitOfWork.RollBackTransaction(cancellationToken);
                throw;
            }
        }
        private async Task<CommonPackageDataResult> MappingCommonPackageProperities(
            PackageAbstractClassDto dto,
            bool isService)
        {
            int maxId = await _packageHeaderRepo.FindMaxId(e => e.id);

            int pkgId = await _packageHeaderRepo.GetMaxIdPyParameter(
                p => p.project_id == dto.project_id &&
                     p.industry_id == dto.industry_id &&
                     p.is_service == isService,
                p => p.pkg_num);

            int index = dto.package_name.IndexOf('/');

            string industryResult = index >= 0
                ? dto.package_name.Substring(index + 1)
                : dto.package_name;

            string pkgName = dto.package_name + "/" +
                             (pkgId + 1).ToString("00");

            var package = new PackagesHeader
            {
                pkg_name = pkgName,
                assign_type = dto.assign_type,
                project_id = dto.project_id,
                industry_id = dto.industry_id,
                assigned_by = dto.assigned_by,
                //file_path = dto.filePath,
                currency = dto.currency,
                type = dto.type,
                expiration_date = dto.expiration_date,
                pkg_num = pkgId + 1,
            };

            return new CommonPackageDataResult
            {
                CommonPackageHeader = package,
                max_id = maxId,
                industryResult = industryResult
            };
        }
    }
}
