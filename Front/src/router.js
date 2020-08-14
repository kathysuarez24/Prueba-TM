import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
    mode:'history',
    base: process.env.BASE_URL,
    routes: [
		{
			path: '/',
            name: 'login',
			component: () => import (/* webpackChunkName: "home" */ './views/Login.vue')
		},
		{
			path: '/home',
            name: 'home',
			component: () => import (/* webpackChunkName: "home" */ './views/Home.vue')
		},
		{
			path: '/listadoUsuario',
            name: 'listadoUsuario',
			component: () => import (/* webpackChunkName: "tareas-crud" */ './components/usuarios/ListadoUsuario.vue')
		},
		{
			path: '/createUsuario',
            name: 'createUsuario',
			component: () => import (/* webpackChunkName: "tareas-crud" */ './components/usuarios/CreateUsuario.vue')
		},
		{
			path: '/editUsuario/:id',
            name: 'editUsuario',
			component: () => import (/* webpackChunkName: "tareas-crud" */ './components/usuarios/EditUsuario.vue')
		},
		{
			path: '/listadoRol',
            name: 'listadoRol',
			component: () => import (/* webpackChunkName: "tareas-crud" */ './components/roles/ListadoRol.vue')
		},
		{
			path: '/createRol',
            name: 'createRol',
			component: () => import (/* webpackChunkName: "tareas-crud" */ './components/roles/CreateRol.vue')
		},
		{
			path: '/editRol/:id',
            name: 'editRol',
			component: () => import (/* webpackChunkName: "tareas-crud" */ './components/roles/EditRol.vue')
		},
		{
			path: '/registro',
            name: 'registro',
			component: () => import (/* webpackChunkName: "tareas-crud" */ './views/Registro.vue')
		},
		{
			path: '/appbar',
            name: 'appbar',
			component: () => import (/* webpackChunkName: "tareas-crud" */ './components/appbar.vue')
		},
	]

})