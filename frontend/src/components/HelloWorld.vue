<template>
  <br />
  <v-card max-width="800" class="mx-auto" color="grey-lighten-3">
    <v-layout>
      <v-app-bar color="teal-darken-4">
        <template v-slot:image>
          <v-img gradient="to top right, rgba(19,84,122,.8), rgba(128,208,199,.8)"></v-img>
        </template>

        <template v-slot:prepend>
          <v-app-bar-nav-icon></v-app-bar-nav-icon>
        </template>
        <v-app-bar-title>Demo</v-app-bar-title>
        <v-spacer></v-spacer>
      </v-app-bar>
      <v-main>
        <v-container fluid>
          <v-table height="300px">
            <thead>
              <tr>
                <th class="text-left">
                  Id
                </th>
                <th class="text-left">
                  Name
                </th>
                <th class="text-left">
                  Sex
                </th>
                <th class="text-left">
                  Operation
                </th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="item in desserts" :key="item.name">
                <td>{{ item.id }}</td>
                <td>{{ item.name }}</td>
                <td>{{ item.sex ? 'Male' : 'FeMale' }}</td>
                <td><v-btn color="error" @click="deleteRow(item.id)">Delete</v-btn></td>
              </tr>
            </tbody>
          </v-table>
        </v-container>
        <div text-align="center">
          <v-row justify="center" align="center">
            <v-col cols="auto">
              <v-btn color="info" @click="dialogOpen = true; demo = {}">Add</v-btn>
            </v-col>
          </v-row>
          <br/>
        </div>
      </v-main>
    </v-layout>
  </v-card>
  <v-row justify="center">
    <v-dialog
      v-model="dialogOpen"
      persistent
      width="1024"
    >
      <v-card>
        <v-card-title>
          <span class="text-h5">Add Demo</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col
                cols="12"
                sm="6"
                md="4"
              >
                <v-text-field
                v-model="demo.name" label="Name"
                ></v-text-field>
              </v-col>
              <v-col
                cols="12"
                sm="6"
                md="4"
              >
              <v-select label="Sex" v-model="demo.sex" item-title="label" item-value="value" :items="sexItems"/>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="blue-darken-1"
            variant="text"
            @click="dialogOpen = false"
          >
            Close
          </v-btn>
          <v-btn
            color="blue-darken-1"
            variant="text"
            @click="addDemo()"
          >
            Save
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      desserts: [],
      dialogOpen: false,
      demo: {},
      sexItems:[
        {
          label: 'Male',
          value: true
        },
        {
          label: 'FeMale',
          value: false
        }
      ]
    }
  },
  methods: {
    deleteRow(id) {
      var vm = this
      axios.delete('http://18.144.14.165:8888/api/toItem/' + id)
        .then(function (response) {
          vm.refreshRow()
        })
        .catch(function (error) {
          console.log(error);
        })
    },
    addDemo(){
      this.dialogOpen = false
      let vm = this
      axios.post('http://18.144.14.165:8888/api/toItem', this.demo)
        .then(function (response) {
          vm.refreshRow()
        })
        .catch(function (error) {
          console.log(error);
        })
    },
    refreshRow() {
      var vm = this
      axios.get('http://18.144.14.165:8888/api/toItem')
        .then(function (response) {
          vm.desserts = response.data
        })
        .catch(function (error) {
          // 处理错误情况
          console.log(error);
        })
    }
  },
  mounted() {
    this.refreshRow()
  }
}
</script>