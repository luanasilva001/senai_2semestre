import React, { Component } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { StyleSheet, TextInput, Image, Text, TouchableOpacity, View } from 'react-native';
import api from '../services/api';

export default class Cadastro extends Component
{
    constructor(props)
    {
        super(props);
        this.state = {
            tema: 0,
            projeto: '',
        }
    }

    cadastro = async () =>{
        try {
            const valorToken = await AsyncStorage.getItem('userToken')

            console.warn(valorToken)

             const resp = await api.post('/projetos', {

                 idTema : this.state.tema,
                 projeto1: this.state.projeto,

                },
                {
                    headers: {
                        'Authorization' : 'Bearer ' + valorToken
                    }
                }
                );

        } catch (error) {
            console.warn(error)
        }
    }

    logout = async () => {

        try {
            
            await AsyncStorage.removeItem('userToken');
            this.props.navigation.navigate('login');

        } catch (error) {
            console.warn(error)
        }
    }

    logout = () =>{
        this.props.navigation.navigate('login')
    }

    render()
    {
        return(
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

                <View style={styles.tituloCadastro}>
                    <Text style={styles.tituloText}>cadastro</Text>
                </View>

                <View style={styles.inputCadastro}>
                    <View style={styles.backInput}>
                        <View style={styles.inputMeio}>
                            <Text style={styles.inputText}>Tema</Text>
                            <Text style={styles.inputText}>Projeto</Text>
                        </View>

                        <View style={styles.inputMeio}>
                            <TextInput
                                style={styles.input}
                                onChangeText={tema => this.setState({tema})}
                            />
                            <TextInput
                                style={styles.input}
                                onChangeText={projeto => this.setState({projeto})}
                            />
                        </View>
                    </View>

                    <View style={styles.btnInput}>
                        <TouchableOpacity style={styles.btnCadastrar} onPress={this.cadastro}>
                            <Text style={styles.btnText}>cadastrar</Text>
                        </TouchableOpacity>
                    </View>
                </View>
            </View>
        );
    }
}

const styles = StyleSheet.create({
    tela: {
        flex: 1
    },

    headerHome: {
        flex: 0.12,
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

    tituloCadastro: {
        height: 70,
        justifyContent: 'center',
        alignItems: 'center'
        // backgroundColor: 'red',
    },
    
    tituloText: {
        fontSize: 35,
        fontFamily: 'Arial',
        textTransform: 'uppercase',
    },
    
    inputCadastro: {
        flex: 0.775,
        backgroundColor: '#00A359',
        justifyContent: 'center',
        justifyContent: 'space-around',
    }, 
    
    backInput: {
        flex: 0.7,
        // backgroundColor: 'red',
        flexDirection: 'row',
    },

    inputMeio: {
        flex: 0.5,
        // backgroundColor: 'blue',
        justifyContent: 'center',
        justifyContent: 'space-around',
    },
    
    inputText: {
        paddingLeft: 30,
        fontSize: 35,
        fontFamily: 'Arial',
        color: 'white',
    },
    
    input: {
        width: 200,
        height: 32,
        backgroundColor: 'white',
        borderWidth: 2,
        borderColor: 'black',
        borderRadius: 4,
        fontSize: 18,
        fontFamily: 'Arial',
        color: 'black',
    },

    btnInput: {
        flex: 0.15,
        // backgroundColor: 'blue',
        alignItems: 'center',
    },
    
    btnCadastrar: {
        paddingTop: 10,
        paddingBottom: 10,
        paddingLeft: 20,
        paddingRight: 20,
        backgroundColor: 'white',
        borderRadius: 5,
    },

    btnText: {
        fontSize: 23,
        fontFamily: 'Arial',
        textTransform: 'uppercase',
    }
})