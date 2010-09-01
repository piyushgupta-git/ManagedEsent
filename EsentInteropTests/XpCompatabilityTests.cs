﻿//-----------------------------------------------------------------------
// <copyright file="XpCompatabilityTests.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.
// </copyright>
//-----------------------------------------------------------------------

namespace InteropApiTests
{
    using System;
    using System.IO;
    using Microsoft.Isam.Esent.Interop;
    using Microsoft.Isam.Esent.Interop.Implementation;
    using Microsoft.Isam.Esent.Interop.Server2003;
    using Microsoft.Isam.Esent.Interop.Vista;
    using Microsoft.Isam.Esent.Interop.Windows7;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test the Api class functionality when we have an XP version of Esent.
    /// </summary>
    [TestClass]
    public class XpCompatabilityTests
    {
        /// <summary>
        /// The saved API, replaced when finished.
        /// </summary>
        private IJetApi savedImpl;

        /// <summary>
        /// Create an implementation with a fixed version.
        /// </summary>
        [TestInitialize]
        [Description("Setup the XpCompatabilityTests fixture")]
        public void Setup()
        {
            this.savedImpl = Api.Impl;
            Api.Impl = new JetApi(Constants.XpVersion);
        }

        /// <summary>
        /// Cleanup after the test.
        /// </summary>
        [TestCleanup]
        [Description("Cleanup the XpCompatabilityTests fixture")]
        public void Teardown()
        {
            Api.Impl = this.savedImpl;
        }

        /// <summary>
        /// Verify the XP version of ESENT doesn't support large keys.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify the XP version of ESENT doesn't support large keys")]
        public void VerifyXpDoesNotSupportLargeKeys()
        {
            Assert.IsFalse(EsentVersion.SupportsLargeKeys);
        }

        /// <summary>
        /// Verify the XP version of ESENT doesn't support Windows Server 2003 features.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify the XP version of ESENT doesn't support Windows Server 2003 features")]
        public void VerifyXpDoesNotSupportServer2003Features()
        {
            Assert.IsFalse(EsentVersion.SupportsServer2003Features);
        }

        /// <summary>
        /// Verify the XP version of ESENT doesn't support Unicode paths.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify the XP version of ESENT doesn't support Unicode paths")]
        public void VerifyXpDoesNotSupportUnicodePaths()
        {
            Assert.IsFalse(EsentVersion.SupportsUnicodePaths);
        }

        /// <summary>
        /// Verify the XP version of ESENT doesn't support Windows Vista features.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify the XP version of ESENT doesn't support Windows Vista features")]
        public void VerifyXpDoesNotSupportVistaFeatures()
        {
            Assert.IsFalse(EsentVersion.SupportsVistaFeatures);
        }

        /// <summary>
        /// Verify the XP version of ESENT doesn't support Windows 7 features.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify the XP version of ESENT doesn't support Windows 7 features")]
        public void VerifyXpDoesNotSupportWindows7Features()
        {
            Assert.IsFalse(EsentVersion.SupportsWindows7Features);
        }

        /// <summary>
        /// Verify that JetGetThreadStats throws an exception when using the
        /// XP version of ESENT.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify that JetGetThreadStats throws an exception when using the XP version of ESENT")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void VerifyXpThrowsExceptionOnJetGetThreadStats()
        {
            JET_THREADSTATS threadstats;
            VistaApi.JetGetThreadStats(out threadstats);
        }

        /// <summary>
        /// Verify that JetGetThreadStats throws an exception when using the
        /// XP version of ESENT.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify that JetGetInstanceMiscInfo throws an exception when using the XP version of ESENT")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void VerifyXpThrowsExceptionOnJetGetInstanceMiscInfo()
        {
            JET_SIGNATURE signature;
            VistaApi.JetGetInstanceMiscInfo(JET_INSTANCE.Nil, out signature, JET_InstanceMiscInfo.LogSignature);
        }

        /// <summary>
        /// Verify that JetOpenTemporaryTable throws an exception when using the
        /// XP version of ESENT.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify that JetOpenTemporaryTable throws an exception when using the XP version of ESENT")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void VerifyXpThrowsExceptionOnJetOpenTemporaryTable()
        {
            var sesid = new JET_SESID();
            var temporarytable = new JET_OPENTEMPORARYTABLE();
            VistaApi.JetOpenTemporaryTable(sesid, temporarytable);
        }

        /// <summary>
        /// Verify that JetConfigureCrashDump throws an exception when using the
        /// XP version of ESENT.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify that JetConfigureCrashDump throws an exception when using the XP version of ESENT")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void VerifyXpThrowsExceptionOnJetConfigureProcessForCrashDump()
        {
            Windows7Api.JetConfigureProcessForCrashDump(CrashDumpGrbit.None);
        }

        /// <summary>
        /// Verify that JetOSSnapshotPrepareInstance throws an exception when using the
        /// XP version of ESENT.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify that JetOSSnapshotPrepareInstance throws an exception when using the XP version of ESENT")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void VerifyXpThrowsExceptionOnJetOSSnapshotPrepareInstance()
        {
            VistaApi.JetOSSnapshotPrepareInstance(JET_OSSNAPID.Nil, JET_INSTANCE.Nil, SnapshotPrepareInstanceGrbit.None);
        }

        /// <summary>
        /// Verify that JetOSSnapshotGetFreezeInfo throws an exception when using the
        /// XP version of ESENT.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify that JetOSSnapshotGetFreezeInfo throws an exception when using the XP version of ESENT")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void VerifyXpThrowsExceptionOnJetOSSnapshotGetFreezeInfo()
        {
            int ignored;
            JET_INSTANCE_INFO[] ignored2;
            VistaApi.JetOSSnapshotGetFreezeInfo(JET_OSSNAPID.Nil, out ignored, out ignored2, SnapshotGetFreezeInfoGrbit.None);
        }

        /// <summary>
        /// Verify that JetOSSnapshotTruncateLog throws an exception when using the
        /// XP version of ESENT.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify that JetOSSnapshotTruncateLog throws an exception when using the XP version of ESENT")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void VerifyXpThrowsExceptionOnJetOSSnapshotTruncateLog()
        {
            VistaApi.JetOSSnapshotTruncateLog(JET_OSSNAPID.Nil, SnapshotTruncateLogGrbit.None);
        }

        /// <summary>
        /// Verify that JetOSSnapshotTruncateLogInstance throws an exception when using the
        /// XP version of ESENT.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify that JetOSSnapshotTruncateLogInstance throws an exception when using the XP version of ESENT")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void VerifyXpThrowsExceptionOnJetOSSnapshotTruncateLogInstance()
        {
            VistaApi.JetOSSnapshotTruncateLogInstance(JET_OSSNAPID.Nil, JET_INSTANCE.Nil, SnapshotTruncateLogGrbit.None);
        }

        /// <summary>
        /// Verify that JetOSSnapshotEnd throws an exception when using the
        /// XP version of ESENT.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify that JetOSSnapshotEnd throws an exception when using the XP version of ESENT")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void VerifyXpThrowsExceptionOnJetOSSnapshotEnd()
        {
            VistaApi.JetOSSnapshotEnd(JET_OSSNAPID.Nil, SnapshotEndGrbit.None);
        }

        /// <summary>
        /// Verify that JetOSSnapshotAbort throws an exception when using the
        /// XP version of ESENT.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify that JetOSSnapshotAbort throws an exception when using the XP version of ESENT")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void VerifyXpThrowsExceptionOnJetOSSnapshotAbort()
        {
            Server2003Api.JetOSSnapshotAbort(JET_OSSNAPID.Nil, SnapshotAbortGrbit.None);
        }

        /// <summary>
        /// Verify that JetUpdate2 throws an exception when using the
        /// XP version of ESENT.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify that JetUpdate2 throws an exception when using the XP version of ESENT")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void VerifyXpThrowsExceptionOnJetUpdate2()
        {
            int actual;
            Server2003Api.JetUpdate2(JET_SESID.Nil, JET_TABLEID.Nil, null, 0, out actual, UpdateGrbit.None);
        }

        /// <summary>
        /// Verify that JetPrereadKeys throws an exception when using the
        /// XP version of ESENT.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify that JetPrereadKeys throws an exception when using the XP version of ESENT")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void VerifyXpThrowsExceptionOnJetPrereadKeys()
        {
            int ignored;
            Windows7Api.JetPrereadKeys(JET_SESID.Nil, JET_TABLEID.Nil, null, null, 0, out ignored, PrereadKeysGrbit.Forward);
        }

        /// <summary>
        /// Verify that JetInit3 throws an exception when using the
        /// XP version of ESENT.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify that JetInit3 throws an exception when using the XP version of ESENT")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void VerifyXpThrowsExceptionOnJetInit3()
        {
            JET_INSTANCE instance = JET_INSTANCE.Nil;
            VistaApi.JetInit3(ref instance, null, InitGrbit.None);
        }

        /// <summary>
        /// Verify getting the LVChunk size on XP returns a default value.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify getting the LVChunk size on XP returns a default value")]
        public void VerifyXpReturnsCorrectLVChunkSize()
        {
            Assert.AreEqual(SystemParameters.DatabasePageSize - 82, SystemParameters.LVChunkSizeMost);
        }

        /// <summary>
        /// Verify getting the cached closed tables system parameter on XP returns 0.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify getting the cached closed tables system parameter on XP returns 0")]
        public void VerifyXpReturns0ForCachedClosedTables()
        {
            using (var instance = new Instance("XPcacheclosedtables"))
            {
                instance.Parameters.CachedClosedTables = 10;
                Assert.AreEqual(0, instance.Parameters.CachedClosedTables);
            }
        }

        /// <summary>
        /// Verify getting the waypoint system parameter on XP returns 0.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify getting the waypoint system parameter on XP returns 0")]
        public void VerifyXpReturns0ForWaypoint()
        {
            using (var instance = new Instance("XPwaypointlatency"))
            {
                instance.Parameters.WaypointLatency = 10;
                Assert.AreEqual(0, instance.Parameters.WaypointLatency);
            }
        }

        /// <summary>
        /// Verify getting the waypoint system parameter on XP returns 0.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify getting the waypoint system parameter on XP returns 0")]
        public void VerifyXpReturnsNullForAlternateRecoveryDirectory()
        {
            using (var instance = new Instance("XPalternaterecovery"))
            {
                instance.Parameters.AlternateDatabaseRecoveryDirectory = @"c:\foo";
                Assert.IsNull(instance.Parameters.AlternateDatabaseRecoveryDirectory);
            }
        }

        /// <summary>
        /// Verify getting the configuration system parameter on XP returns 0.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify getting the configuration system parameter on XP returns 0")]
        public void VerifyXpReturns1ForConfiguration()
        {
            SystemParameters.Configuration = 0;
            Assert.AreEqual(1, SystemParameters.Configuration);
        }

        /// <summary>
        /// Verify getting the enable advanced system parameter on XP returns true.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify getting the enable advanced system parameter on XP returns true")]
        public void VerifyXpReturnsTrueForEnableAdvanced()
        {
            SystemParameters.EnableAdvanced = false;
            Assert.AreEqual(true, SystemParameters.EnableAdvanced);
        }

        /// <summary>
        /// Verify getting the key most system parameter on XP returns 255.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [Description("Verify getting the key most system parameter on XP returns 255")]
        public void VerifyXpReturns255ForKeyMost()
        {
            Assert.AreEqual(255, SystemParameters.KeyMost);
        }

        /// <summary>
        /// Use JetCreateIndex2 on XP to test the compatability path.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        [Description("Use JetCreateIndex2 on XP to test the compatability path")]
        public void CreateIndexesOnXp()
        {
            string directory = SetupHelper.CreateRandomDirectory();
            string database = Path.Combine(directory, "test.db");

            using (var instance = new Instance("XPcreateindexes"))
            {
                instance.Parameters.Recovery = false;
                instance.Parameters.NoInformationEvent = true;
                instance.Parameters.MaxTemporaryTables = 0;
                instance.Parameters.TempDirectory = directory;
                instance.Init();
                using (var session = new Session(instance))
                {
                    JET_DBID dbid;
                    Api.JetCreateDatabase(session, database, String.Empty, out dbid, CreateDatabaseGrbit.None);
                    using (var transaction = new Transaction(session))
                    {
                        JET_TABLEID tableid;
                        Api.JetCreateTable(session, dbid, "table", 0, 100, out tableid);
                        JET_COLUMNID columnid;
                        Api.JetAddColumn(
                            session,
                            tableid,
                            "column1",
                            new JET_COLUMNDEF { coltyp = JET_coltyp.Long },
                            null,
                            0,
                            out columnid);

                        var indexcreates = new[]
                        {
                            new JET_INDEXCREATE
                            {
                                szKey = "+column1\0",
                                cbKey = 10,
                                szIndexName = "index1",
                                pidxUnicode = new JET_UNICODEINDEX { lcid = 1033 },
                            },
                        };

                        Api.JetCreateIndex2(session, tableid, indexcreates, indexcreates.Length);
                        transaction.Commit(CommitTransactionGrbit.LazyFlush);
                    }
                }
            }

            Cleanup.DeleteDirectoryWithRetry(directory);
        }

        /// <summary>
        /// Use JetGetRecordSize on XP to test the compatability path. This also tests
        /// the handling of the running total option.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        [Description("Use JetGetRecordSize on XP to test the compatability path")]
        public void GetRecordSizeOnXp()
        {
            string directory = SetupHelper.CreateRandomDirectory();
            string database = Path.Combine(directory, "test.db");

            using (var instance = new Instance("XPgetrecordsize"))
            {
                instance.Parameters.Recovery = false;
                instance.Parameters.NoInformationEvent = true;
                instance.Parameters.MaxTemporaryTables = 0;
                instance.Init();
                using (var session = new Session(instance))
                {
                    JET_DBID dbid;
                    Api.JetCreateDatabase(session, database, String.Empty, out dbid, CreateDatabaseGrbit.None);
                    using (var transaction = new Transaction(session))
                    {
                        JET_TABLEID tableid;
                        Api.JetCreateTable(session, dbid, "table", 0, 100, out tableid);
                        JET_COLUMNID columnid;
                        Api.JetAddColumn(
                            session,
                            tableid,
                            "column1",
                            new JET_COLUMNDEF { coltyp = JET_coltyp.LongBinary },
                            null,
                            0,
                            out columnid);

                        var size = new JET_RECSIZE();
                        byte[] data = Any.Bytes;

                        using (var update = new Update(session, tableid, JET_prep.Insert))
                        {
                            Api.SetColumn(session, tableid, columnid, data);
                            Api.JetGetRecordSize(session, tableid, ref size, GetRecordSizeGrbit.Local | GetRecordSizeGrbit.InCopyBuffer);
                            update.SaveAndGotoBookmark();
                        }

                        Api.JetGetRecordSize(session, tableid, ref size, GetRecordSizeGrbit.RunningTotal);

                        Assert.AreEqual(data.Length * 2, size.cbData, "cbData");
                        Assert.AreEqual(data.Length * 2, size.cbDataCompressed, "cbDataCompressed");
                        Assert.AreEqual(0, size.cbLongValueData, "cbLongValueData");
                        Assert.AreEqual(0, size.cbLongValueDataCompressed, "cbLongValueDataCompressed");
                        Assert.AreEqual(0, size.cbLongValueOverhead, "cbLongValueOverhead");
                        Assert.AreNotEqual(0, size.cbOverhead, "cbOverhead");
                        Assert.AreEqual(0, size.cCompressedColumns, "cCompressedColumns");
                        Assert.AreEqual(0, size.cLongValues, "cLongValues");
                        Assert.AreEqual(0, size.cMultiValues, "cMultiValues");
                        Assert.AreEqual(0, size.cNonTaggedColumns, "cTaggedColumns");
                        Assert.AreEqual(2, size.cTaggedColumns, "cTaggedColumns");

                        transaction.Commit(CommitTransactionGrbit.LazyFlush);
                    }
                }
            }

            Cleanup.DeleteDirectoryWithRetry(directory);
        }
    }
}