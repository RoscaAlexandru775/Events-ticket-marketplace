import { Routes } from '@angular/router';
import { AuthGuard } from '../components/guards/auth.guard';
import { DashboardAdminComponent } from './dashboard-admin/dashboard-admin.component';
import { SingupAdminComponent } from './singup-admin/singup-admin.component';

export const routes: Routes = [
    {
        path: 'dashboard',
        component: DashboardAdminComponent,
        canActivate: [AuthGuard],
        children: [
            { path: '', redirectTo: 'login', pathMatch: 'full' },
            {
                path: 'admin',
                component: SingupAdminComponent
            },
            // {
            //     path: 'details',
            //     component: DetailsComponent
            // },
            // {
            //     path: 'details/:idFromUrl',
            //     component: DetailsComponent
            // }
        ]
    }
];
