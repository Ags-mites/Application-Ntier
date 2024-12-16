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
    }
}
