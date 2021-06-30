import AsyncStorage from '@react-native-async-storage/async-storage';
import React, { Component } from 'react';
import { StyleSheet, Image, Text, TouchableOpacity, View, ScrollView } from 'react-native';
import { FlatList } from 'react-native-gesture-handler';
import api from '../services/api';

export default class Home extends Component{
    constructor(props)
    {
        super(props);
        this.state = {
            listaTarefa : []
        }
    }

    listaTarefa = async () => {
        const valorToken = await AsyncStorage.getItem('userToken');

        const resp = await api.get('/projetos/listartodas',
          {
              headers: {
                  'Authorization' : 'Bearer ' + valorToken
              }
          }  
        );
        const dadosApi = resp.data;
        this.setState({listaTarefa : dadosApi})
    }

    componentDidMount(){
        this.listaTarefa();
    }

    logout = async () => {

        try {
            
            await AsyncStorage.removeItem('userToken');
            this.props.navigation.navigate('login');

        } catch (error) {
            console.warn(error)
        }
    }

  render()
  {
    return (
        <View style={styles.tela}>

            <View style={styles.headerHome}>
    
                <View style={styles.headerMeio}>
                    <TouchableOpacity
                        style={styles.logoutHome}
                        onPress={this.logout}
                    >
                        <Image
                            source={require('../../assets/Img/seta.png')}
                            style={styles.logoutImg}
                        />
    
                        <Text style={styles.logoutText}>logout</Text>
                    </TouchableOpacity>
                </View>
    
                <View style={styles.headerMeio2}>
                    <Image
                        source={require('../../assets/Img/logoHeader.png')}
                        style={styles.headerLogo}
                    />
                </View>
            </View>
    
            <View style={styles.bemVindoHome}>
                <View style={styles.bemVindo}>
                    <Text style={styles.bemVindoText}>bem vindo</Text>
                </View>
            </View>

            <View style={styles.TarefaHome}>
                <Text style={styles.tarefaText}>tarefas</Text>
            </View>

            <ScrollView>

                <FlatList
                    data={this.state.listaTarefa}
                    keyExtractor={ item => item.projeto1}
                    renderItem={this.renderItem}
                />

            </ScrollView>
        
        </View>
            
      );

    }
    
    renderItem = ({ item }) => (
        <ScrollView style={styles.listaTarefa}>
                <Text style={styles.listaTarefaText}>PROJETO: {item.projeto1}</Text>
                <Text style={styles.listaTarefaText}>TEMA: {item.idTemaNavigation.tituloTema}</Text>
                <Text style={styles.listaTarefaText}>PROFESSOR: {item.idUsuarioNavigation.nomeUsuario}</Text>
                <View style={styles.linhaTarefa}></View>
            </ScrollView>
    );
 
}

const styles = StyleSheet.create({
    tela: {
        flex: 1
    },

    headerHome: {
        backgroundColor: 'black',
        flexDirection: 'row',
    },

    headerMeio: {
        flex: 0.5,
        justifyContent: 'center',
        // backgroundColor: 'red',
    },

    logoutHome: {
        width: 170,
        height: 55,
        alignItems: 'center',
        justifyContent: 'space-around',
        flexDirection: 'row',
        // backgroundColor: 'blue',
    },

    logoutImg: {
        width: 50,
        height: 50,
        tintColor: 'white',
    },

    logoutText: {
        fontFamily: 'Arial',
        fontSize: 25,
        color: 'white',
        textTransform: 'uppercase',
    },

    headerMeio2: {
        flex: 0.5,
        justifyContent: 'center',
        alignItems: 'flex-end',
        // backgroundColor: 'blue'
    },

    headerLogo: {
        width: 130,
        height: 60,
    },

    bemVindoHome: {
        marginTop: 20,
        marginBottom: 20,
        // backgroundColor: 'red'
    },  

    bemVindo: {
        // backgroundColor: 'blue',
        alignItems: 'center',
        justifyContent: 'center'
    },
    
    bemVindoText: {
        color: 'black',
        fontFamily: 'Arial',
        fontSize: 35,
        textTransform: 'uppercase',
    },

    TarefaHome: {
        marginBottom: 20,
        backgroundColor: 'rgba(0, 183, 100, 1)',
        justifyContent: 'center',
        alignItems : 'center',
    },

    tarefaText: {
        fontSize: 35,
        fontFamily: 'Arial',
        textTransform: 'uppercase',
        color: 'white'
    },

    listaTarefa: {
        flex: 'auto',
        marginBottom: 15,
        // backgroundColor: 'red'
    },

    listaTarefaText: {
        marginBottom: 3,
        marginLeft: 30,
        fontFamily: 'Arial',
        fontSize: 18,
    },

    linhaTarefa: {
        margin: 'auto',
        width: 400,
        height: 2,
        backgroundColor: 'gray'
    },
});