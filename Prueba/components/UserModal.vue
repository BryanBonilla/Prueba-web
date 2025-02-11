<template>
  <div v-if="modalType" class="modal fade show" style="display: block;" tabindex="-1" aria-labelledby="exampleModalLabel"
    aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-md">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">{{ modalTitle }}</h5>
          <button type="button" class="btn-close" @click="closeModal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="handleSubmit">
            <div class="mb-3">
              <label for="firstName" class="form-label">Nombre</label>
              <input v-model="localUser.firstName" type="text" class="form-control" :readonly="isViewMode" />
            </div>
            <div class="mb-3">
              <label for="lastName" class="form-label">Apellido</label>
              <input v-model="localUser.lastName" type="text" class="form-control" :readonly="isViewMode" />
            </div>
            <div class="mb-3">
              <label for="email" class="form-label">Correo electrónico</label>
              <input v-model="localUser.email" type="email" class="form-control" :readonly="isViewMode" />
            </div>
            <div class="mb-3">
              <label for="phoneNumber" class="form-label">Teléfono</label>
              <input v-model="localUser.phoneNumber" type="text" class="form-control" :readonly="isViewMode" />
            </div>
            <div class="mb-3" v-if="modalType !== 'view'">
              <label for="role" class="form-label">Rol</label>
              <select v-model="localUser.role" class="form-select">
                <option value="Administrador">Administrador</option>
                <option value="Cliente">Cliente</option>
              </select>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" @click="closeModal">Cancelar</button>
              <button v-if="modalType !== 'view'" type="submit" class="btn btn-primary">Confirmar</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    modalType: String,
    user: Object
  },
  data() {
    return {
      localUser: { ...this.user } // ✅ Copia el objeto `user` en `localUser`
    };
  },
  computed: {
    modalTitle() {
      switch (this.modalType) {
        case 'create': return 'Agregar Usuario';
        case 'edit': return 'Editar Usuario';
        case 'view': return 'Ver Usuario';
        case 'delete': return 'Eliminar Usuario';
        default: return '';
      }
    },
    isViewMode() {
      return this.modalType === 'view';
    }
  },
  watch: {
    user: {
      handler(newUser) {
        this.localUser = { ...newUser }; // ✅ Reactualiza `localUser` cuando cambia `user`
      },
      deep: true,
      immediate: true
    }
  },
  methods: {
    closeModal() {
      this.$emit('close');
    },
    handleSubmit() {
      if (this.modalType === 'create') {
        this.$emit('add-user', this.localUser);
      } else if (this.modalType === 'edit') {
        this.$emit('edit-user', this.localUser);
      }
    }
  }
};
</script>
