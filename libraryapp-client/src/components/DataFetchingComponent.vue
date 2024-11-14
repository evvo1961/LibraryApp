<template>
    <div>
        <h1>Books</h1>

        <table class="table">
            <tr>
                <th>Id</th>
                <th>Title</th>
                <th>Author</th>
                <th>Publication Date</th>
                <th>Edition Number</th>
                <th>ISBN</th>
            </tr>
            <tbody>
                <tr v-for="item in items" :key="item.id">
                    <td>{{item.id}}</td>
                    <td>{{item.title }}</td>
                    <td>{{item.author }}</td>
                    <td>{{new Date(item.publicationDate).toLocaleDateString("en-GB")}}</td>
                    <td>{{item.editionNumber}}</td>
                    <td>{{item.isbn}}</td>
                </tr>                
            </tbody>
        </table>
    </div>
</template>

<script>
import axios from 'axios';

    export default {
        data() {
            return {                
                items: []
            };
        },
    mounted() {
    const apiUrl = 'https://localhost:7100/api/Book/GetAllBooks'; 

    axios.get(apiUrl)
      .then((response) => {          
          this.items = response.data;
          console.log(this.items);  
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
      });
  },
};
</script>