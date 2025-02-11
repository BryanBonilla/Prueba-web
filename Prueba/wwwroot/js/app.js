import {createApp} from 'vue'
import UserTable from './UserTable.vue'

const app = createApp({
    components:{
        'user-table': UserTable
    }
});

app.mount('#app')