using PersistenceLayer;
using PersistenceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class VoucherService
    {
        private readonly EntryHeaderRepository _entryHeaderRepository;
        private readonly EntryDetailRepository _entryDetailRepository;

        public VoucherService()
        {
            _entryHeaderRepository = new EntryHeaderRepository();
            _entryDetailRepository = new EntryDetailRepository();
        }

        public void AddVoucher(string voucherData)
        {

            try
            { 
                
                var parts = voucherData.Split('|');
                var headerParts = parts[0].Split(';'); 
                var rowPartsArray = parts.Skip(1).ToArray();


                var entryHeader = new EntryHeader
                {
                    entry_date = DateTime.Parse(headerParts[3]), 
                    voucher_type = headerParts[0],              
                    numeration = headerParts[1],                
                    notes = headerParts[2],                     
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };
               
                int entryHeaderId = _entryHeaderRepository.Create(entryHeader);
                var entryDetails = new List<EntryDetail>();

                foreach (var row in rowPartsArray)
                {
                    var rowParts = row.Split(';');
                    var detail = new EntryDetail
                    {
                        entry_id = entryHeaderId,
                        account = int.Parse(rowParts[0]),       
                        description = rowParts[1],              
                        debit_amount = decimal.Parse(rowParts[2]),  
                        credit_amount = decimal.Parse(rowParts[3]),
                        created_at = DateTime.Now,
                        updated_at = DateTime.Now
                    };

                    entryDetails.Add(detail);
                }

                _entryDetailRepository.CreateMultiple(entryDetails);

                Console.WriteLine("Voucher creado exitosamente.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el voucher: {ex.Message}");
                throw;
            }
        }

        public List<EntryDetail> GetEntryDetailsbyEntryHeader(string id)
        {
            var entryHeader = int.Parse(id);
            var result = _entryDetailRepository.GetEntryDetailsbyEntryHeader(entryHeader);
            
            return result;
        }

        public List<EntryHeader> GetEntryHeaderRepository()
        {
            return _entryHeaderRepository.GetAllEntryHeader();
        }

        public async Task DeleteVoucherId(int id)
        {
            await _entryDetailRepository.DeleteDetailbyHeaderId(id);
            await _entryHeaderRepository.DeleteHeaderId(id);
        }

        public List<EntryHeader> SearchEntryHeader(string keyword)
        {
            return _entryHeaderRepository.Search(keyword);
        }

        public async Task UpdateVoucher(string voucherData)
        {
            try
            {
                var parts = voucherData.Split('|');
                var headerParts = parts[0].Split(';');
                var rowPartsArray = parts.Skip(1).Take(parts.Length - 2).ToArray();
                var voucherId = parts.Last();

                var entryHeader = new EntryHeader
                {
                    entry_date = DateTime.Now,
                    voucher_type = headerParts[0],
                    numeration = headerParts[1],
                    notes = headerParts[2],
                    updated_at = DateTime.Now
                };

                entryHeader.id = int.Parse(voucherId);
                await _entryHeaderRepository.UpdateHeader(entryHeader);

                var entryDetails = new List<EntryDetail>();
                var entryDetailsNew = new List<EntryDetail>();

                foreach (var row in rowPartsArray)
                {
                    var rowParts = row.Split(';');
                    if (rowParts.Length >= 4)
                    {
                        if (rowParts.Length == 5 && string.IsNullOrEmpty(rowParts[4]))
                        {
                            var detailNew = new EntryDetail
                            {
                                entry_id = entryHeader.id,
                                account = int.Parse(rowParts[0]),
                                description = rowParts[1],
                                debit_amount = decimal.Parse(rowParts[2]),
                                credit_amount = decimal.Parse(rowParts[3]),
                                created_at = DateTime.Now,
                                updated_at = DateTime.Now
                            };
                            Console.WriteLine($"Entry Header: {detailNew}");
                            entryDetailsNew.Add(detailNew);
                            continue;
                        }
                        else
                        {
                            var detail = new EntryDetail
                            {
                                entry_id = entryHeader.id,
                                account = int.Parse(rowParts[0]),
                                description = rowParts[1],
                                debit_amount = decimal.Parse(rowParts[2]),
                                credit_amount = decimal.Parse(rowParts[3]),
                                updated_at = DateTime.Now
                            };
                            Console.WriteLine($"Entry Header: {detail}");
                            entryDetails.Add(detail);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error en la fila: {string.Join(";", rowParts)}. No tiene suficientes partes.");
                    }

                }

                if (entryDetailsNew.Any())
                {
                    await _entryDetailRepository.CreateMultipleAsync(entryDetailsNew);
                }

                if (entryDetails.Any())
                {
                    await _entryDetailRepository.UpdateMultiple(entryDetails);
                }

                Console.WriteLine("Voucher actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el voucher: {ex.Message}");
                throw;
            }
        }



    }
}
