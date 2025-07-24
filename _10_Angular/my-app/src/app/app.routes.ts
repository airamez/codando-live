import { Routes } from '@angular/router';
import { Home } from './home/home';
import { About } from './about/about';
import { User } from './user/user';
import { Posts } from './service-demo/posts/posts';

export const routes: Routes = [
  //  { path: '', component: Home }, // Default route
  //  { path: 'about', component: About }, // Static route
  //  { path: 'user/:id', component: User }, // Route with parameter
   { path: 'posts/:userId', component: Posts },
   { path: '**', redirectTo: '', pathMatch: 'full' } // Wildcard route for 404
];
