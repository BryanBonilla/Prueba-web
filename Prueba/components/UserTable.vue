<template>
  <div class="container">
    <div class="row">
      <div class="col-md-12 options-head">
        <h2 class="title-section">Usuarios</h2>
        <div class="actions-head">
          <div class="input-group input-search">
            <span class="input-group-text" id=""><i class="bi bi-search"></i></span>
            <input v-model="searchQuery" type="text" class="form-control" placeholder="Buscar" />
          </div>
          <button class="btn btn-primary" @click="openModal('create')">Agregar usuario</button>
        </div>
      </div>
    </div>
    <div class="row mt-3">
      <div class="col-md-12">
        <table class="table table-striped" id="dataTable">
          <thead>
            <tr>
              <th>Nombre</th>
              <th>Apellido</th>
              <th>Correo</th>
              <th>Teléfono</th>
              <th>Permisos</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="user in filteredUsers" :key="user.id">
              <td>{{ user.firstName }}</td>
              <td>{{ user.lastName }}</td>
              <td>{{ user.email }}</td>
              <td>{{ user.phoneNumber }}</td>
              <td>
                <p :class="user.role === 'Administrador' ? 'rol admin' : 'rol cliente'">{{ user.role }}</p>
              </td>
              <td>
                <div class="dropdown">
                  <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton2"
                    data-bs-toggle="dropdown" aria-expanded="false">
                    <i class="bi bi-three-dots-vertical"></i>
                  </button>
                  <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton2">
                    <li><a class="dropdown-item" @click="openModal('view', user)">Ver detalle</a></li>
                    <li><a class="dropdown-item" @click="openModal('edit', user)">Editar</a></li>
                    <li><a class="dropdown-item" @click="openModal('delete', user)">Eliminar</a></li>
                  </ul>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    
    <!-- Modal de acción (Agregar, Editar, Ver, Eliminar) -->
    <UserModal :modal-type="modalType" :user="selectedUser" @close="closeModal" />
  </div>
</template>

<script>
import UserModal from './UserModal.vue';

export default {
  components: {
    UserModal
  },
  data() {
    return {
      users: [],  // Lista de usuarios
      searchQuery: '',
      modalType: null, // Tipo de modal (create, edit, view, delete)
      selectedUser: null // Usuario seleccionado
    };
  },
  computed: {
    filteredUsers() {
      return this.users.filter(user => user.firstName.toLowerCase().includes(this.searchQuery.toLowerCase()));
    }
  },
  methods: {
    openModal(type, user = null) {
      this.modalType = type;
      this.selectedUser = user;
    },
    closeModal() {
      this.modalType = null;
      this.selectedUser = null;
    }
  },
  mounted() {
    // Aquí deberías cargar la lista de usuarios desde el backend
    this.users = [
      { id: 1, firstName: 'John', lastName: 'Doe', email: 'john@example.com', phoneNumber: '1234567890', role: 'Administrador' },
      { id: 2, firstName: 'Jane', lastName: 'Doe', email: 'jane@example.com', phoneNumber: '0987654321', role: 'Cliente' }
    ];
  }
};
</script>
