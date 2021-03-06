﻿using System;
using System.Threading.Tasks;
using BethanysPieShopHRM.Server.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Server.Components
{
    public class AddEmployeeDialogBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee() { CountryId = 1, JobCategoryId = 1, JoinedDate = DateTime.Now };
        
        [Inject] public IEmployeeDataService EmployeeDataService { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        public bool ShowDialog { get; set; }

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        public void ResetDialog()
        {
            Employee = new Employee() { JobCategoryId = 1, CountryId = 1, JoinedDate = DateTime.Now };
        }

        protected async Task HandleValidSubmit()
        {
            await EmployeeDataService.AddEmployee(Employee);
            await CloseEventCallback.InvokeAsync(true);
            ShowDialog = false;

            StateHasChanged();
        }

    }
}
