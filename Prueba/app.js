import Vue from 'vue';
import UserTable from './Components/UserTable.vue';

Vue.component('user-table', UserTable);

new Vue({
  el: '#app', 
});